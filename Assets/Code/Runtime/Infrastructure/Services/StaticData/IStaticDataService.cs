using Code.Runtime.StaticData;

namespace Code.Runtime.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        PlayerConfig PlayerConfig { get; }
        LevelData GetLevelData(string levelName);
        
        HudConfig HUDConfig { get; }
        
        void LoadAll();
    }
}