using Code.Runtime.Data;
using Code.Runtime.Infrastructure.SaveLoad;
using Code.Runtime.Infrastructure.SaveLoadRegistry;
using Code.Runtime.Infrastructure.Services.Progress;
using Newtonsoft.Json;
using UnityEngine;

namespace Code.Runtime.Infrastructure.Services.SaveLoad
{
    internal sealed class SaveLoadService : ISaveLoadService
    {
        private const string PlayerProgress = "PlayerProgress";

        private readonly IProgressService _progressService;
        private readonly ISaveLoadRegistryService _saveLoadRegistry;

        public SaveLoadService(IProgressService progressService, ISaveLoadRegistryService saveLoadRegistry)
        {
            _progressService = progressService;
            _saveLoadRegistry = saveLoadRegistry;
        }

        public void SaveProgress()
        {
            foreach (IWriteProgress progressWrite in _saveLoadRegistry.ProgressWriter)
            {
                progressWrite.Write((_progressService.PlayerProgress));
            }

            string json = JsonConvert.SerializeObject(_progressService.PlayerProgress);
            PlayerPrefs.SetString(PlayerProgress, json);
        }

        public PlayerProgress LoadProgress()
        {
            string json = PlayerPrefs.GetString(PlayerProgress);

            if (string.IsNullOrEmpty(json))
                return new PlayerProgress();

            return JsonConvert.DeserializeObject<PlayerProgress>(json);
        }
    }
}