using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Code.Runtime.Data;
using Code.Runtime.StaticData;
using UnityEngine;

namespace Code.Runtime.Infrastructure.Services.StaticData
{
    internal sealed class StaticDataService : IStaticDataService
    {
        public HudConfig HUDConfig { get; set; }
        public PlayerConfig PlayerConfig { get; private set; }
        private Dictionary<string, LevelData> _levelsData;
        private Dictionary<HatTypeId, HatConfig> _shopItems;
        public void LoadAll()
        {
            LoadPlayerConfig();
            LoadHudConfig();
            LoadLevels();
            LoadShopItems();
        }

        public HatConfig GetHatConfig(HatTypeId hatTypeId) =>
            _shopItems.GetValueOrDefault(hatTypeId);
        
        public IEnumerable<HatConfig> GetHatsConfigs() =>
            _shopItems.Values;
        
    
        public LevelData GetLevelData(string levelName) => _levelsData[levelName];

        private void LoadShopItems() =>
            _shopItems = Resources
                .LoadAll<HatConfig>(path: "Configs/ShopItems")
                .ToDictionary(x => x.HatTypeId );
        
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