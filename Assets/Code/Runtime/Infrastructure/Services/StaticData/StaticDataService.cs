using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Code.Runtime.Data;
using Code.Runtime.Gameplay.View.UI.Shop;
using Code.Runtime.StaticData;
using UnityEngine;

namespace Code.Runtime.Infrastructure.Services.StaticData
{
    internal sealed class StaticDataService : IStaticDataService
    {
        public HudConfig HUDConfig { get; set; }
        public PlayerConfig PlayerConfig { get; private set; }
        private Dictionary<string, LevelData> _levelsData;
        private Dictionary<ShopItemId, ShopItemConfig> _shopItems;
        private Dictionary<HatTypeId, HatConfig> _hats;
        private Dictionary<JumpTypeId, JumpConfig> _jumps;

        public void LoadAll()
        {
            LoadPlayerConfig();
            LoadHudConfig();
            LoadLevels();
            LoadShopItems();
            LoadHatConfigs();
            LoadJumpConfigs();
        }

        public HatConfig GetHatConfig(HatTypeId hatTypeId) =>
            _hats.GetValueOrDefault(hatTypeId);
        public JumpConfig GetJumpConfig(JumpTypeId jumpTypeId) =>
            _jumps.GetValueOrDefault(jumpTypeId);

        public ShopItemConfig GetShopItemConfig(ShopItemId hatTypeId) =>
            _shopItems.GetValueOrDefault(hatTypeId);
        
        public IEnumerable<ShopItemConfig> GetItemsConfigs() =>
            _shopItems.Values;
        
    
        public LevelData GetLevelData(string levelName) => _levelsData[levelName];

        private void LoadShopItems() =>
            _shopItems = Resources
                .LoadAll<ShopItemConfig>(path: "Configs/ShopItems")
                .ToDictionary(x => x.ShopItemId );

        private void LoadHatConfigs()
        {
            _hats = Resources.LoadAll<HatConfig>("Configs/Hats").ToDictionary(x=>x.HatTypeId);
        }
        private void LoadJumpConfigs()
        {
            _jumps = Resources.LoadAll<JumpConfig>("Configs/Jumps").ToDictionary(x=>x.JumpTypeId);
        }
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