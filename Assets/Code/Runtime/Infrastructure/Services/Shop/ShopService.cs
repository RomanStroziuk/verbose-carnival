using System;
using System.Collections.Generic;
using Code.Runtime.Data;
using Code.Runtime.Gameplay.Service.Wallet;
using Code.Runtime.Infrastructure.SaveLoad;
using Code.Runtime.Infrastructure.Services.SaveLoad;
using Code.Runtime.Infrastructure.Services.StaticData;
using Code.Runtime.StaticData;
using Unity.VisualScripting;

namespace Code.Runtime.Infrastructure.Services.Shop
{
    internal sealed class ShopService : IShopService
    {
        private List<HatTypeId> _ownedHats = new();
        private IStaticDataService _staticDataService;
        private IWalletService _walletService;
        private ISaveLoadService _saveLoadService;
        public ShopService(IStaticDataService staticDataService, IWalletService walletService, ISaveLoadService saveLoadService)
        {
            _staticDataService = staticDataService;
            _walletService = walletService;
            _saveLoadService = saveLoadService;
        }
        
        public bool CanBuyItem(HatTypeId hatType)
        {
            HatConfig config = _staticDataService.GetHatConfig(hatType);
            return _walletService.IsEnoughMoney(config.Price) && !_ownedHats.Contains(hatType);
        }

        public void BuyItem(HatTypeId hatType)
        {
            if (!CanBuyItem(hatType))
                throw new InvalidOperationException("Cannot buy item");
            
            _ownedHats.Add(hatType);
            _walletService.Purchase(_staticDataService.GetHatConfig(hatType).Price);
            _saveLoadService.SavePrograss();
        }


        public void Read(PlayerProgress playerProgress) =>
            _ownedHats = playerProgress.OwnedHats;
        

        public void Write(PlayerProgress playerProgress) =>
            playerProgress.OwnedHats = _ownedHats;
    }
}