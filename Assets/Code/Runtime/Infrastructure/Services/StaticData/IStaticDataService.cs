using System.Collections.Generic;
using Code.Runtime.Data;
using Code.Runtime.Gameplay.View.UI.Shop;
using Code.Runtime.StaticData;

namespace Code.Runtime.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        PlayerConfig PlayerConfig { get; }
        LevelData GetLevelData(string levelName);
        
        HudConfig HUDConfig { get; }
        
        void LoadAll();
        ShopItemConfig GetShopItemConfig(ShopItemId hatTypeId);
        IEnumerable<ShopItemConfig> GetHatsConfigs();
        HatConfig GetHatConfig(HatTypeId hatTypeId);
    }
}