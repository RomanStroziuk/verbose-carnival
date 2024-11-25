using System.Collections.Generic;
using Code.Runtime.Data;
using Code.Runtime.Infrastructure.SaveLoad;
using Code.Runtime.Infrastructure.SaveLoadRegistry;
using Code.Runtime.Infrastructure.Services.Progress;
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
        
        public void SavePrograss()
        {
            foreach (IWriteProgress progressWrite in _saveLoadRegistry.ProgressWriter)
            {
                progressWrite.Write((_progressService.PlayerProgress));
            }
            
            string json = JsonUtility.ToJson(_progressService.PlayerProgress);
            PlayerPrefs.SetString(PlayerProgress, json);
        }

        public PlayerProgress LoadProgress()
        {
            string json = PlayerPrefs.GetString(PlayerProgress);
            return JsonUtility.FromJson<PlayerProgress>(json);
        }
        
    }
}