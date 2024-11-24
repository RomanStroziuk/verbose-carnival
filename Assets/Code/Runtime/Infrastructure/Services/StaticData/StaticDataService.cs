using System.Collections.Generic;
using System.Linq;
using Code.Runtime.StaticData;
using UnityEngine;

namespace Code.Runtime.Infrastructure.Services.StaticData
{
    internal sealed class StaticDataService : IStaticDataService
    {
        public HudConfig HUDConfig { get; set; }
        public PlayerConfig PlayerConfig { get; private set; }
        private Dictionary<string, LevelData> _levelsData;
        public void LoadAll()
        {
            LoadPlayerConfig();
            LoadHudConfig();
            LoadLevels();
        } 

        public LevelData GetLevelData(string levelName) => _levelsData[levelName];

        private void LoadLevels()
        {
            _levelsData = Resources.LoadAll<LevelData>("Configs/Levels").ToDictionary(level => level.LevelName);
        }

        private PlayerConfig LoadPlayerConfig() =>
            PlayerConfig = Resources.Load<PlayerConfig>("Configs/PlayerConfig");

        private void LoadHudConfig()
        {
            HUDConfig = Resources.Load<HudConfig>("Configs/HudConfig");
        }
    }
}