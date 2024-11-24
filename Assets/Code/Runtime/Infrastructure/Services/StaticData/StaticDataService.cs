using Code.Runtime.StaticData;
using UnityEngine;

namespace Code.Runtime.Infrastructure.Services.StaticData
{
    public sealed class StaticDataService : IStaticDataService
    {
        public HudConfig HUDConfig { get; set; }
        public PlayerConfig PlayerConfig { get; private set; }

        public void LoadAll()
        {
            LoadPlayerConfig();
            LoadHudConfig();
        }

        private PlayerConfig LoadPlayerConfig() =>
            PlayerConfig = Resources.Load<PlayerConfig>("Configs/PlayerConfig");

        private void LoadHudConfig()
        {
            HUDConfig = Resources.Load<HudConfig>("Configs/HudConfig");
        }
    }
}