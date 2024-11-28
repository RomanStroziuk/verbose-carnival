using System;
using System.Collections.Generic;
using Code.Runtime.Data;
using Code.Runtime.Gameplay.Service.Wallet;
using Code.Runtime.Gameplay.View.UI.Shop;
using Code.Runtime.Infrastructure.SaveLoad;
using Code.Runtime.Infrastructure.Services.PlayerInventory;
using Code.Runtime.Infrastructure.Services.SaveLoad;
using Code.Runtime.Infrastructure.Services.StaticData;
using Code.Runtime.StaticData;
using Unity.VisualScripting;

namespace Code.Runtime.Infrastructure.Services.Shop
{
    internal sealed class ShopService : IShopService
    {
        private List<ShopItemId> _purchasedItems = new();
        private IStaticDataService _staticDataService;
        private IWalletService _walletService;
        private ISaveLoadService _saveLoadService;
        private IPlayerInventoryService _inventoryService;

        public ShopService(IStaticDataService staticDataService, IWalletService walletService, ISaveLoadService saveLoadService, IPlayerInventoryService inventoryService)
        {
            _staticDataService = staticDataService;
            _walletService = walletService;
            _saveLoadService = saveLoadService;
            _inventoryService = inventoryService;
        }
        
        public bool CanBuyItem(ShopItemId hatType)
        {
            ShopItemConfig config = _staticDataService.GetShopItemConfig(hatType);
            return _walletService.IsEnoughMoney(config.Price) && !_purchasedItems.Contains(hatType);
        }

        public void BuyItem(ShopItemId hatType)
        {
            if (!CanBuyItem(hatType))
                throw new InvalidOperationException("Cannot buy item");
            
            _purchasedItems.Add(hatType);
            ShopItemConfig config = _staticDataService.GetShopItemConfig(hatType);
            _walletService.Purchase(config.Price);
           
            if (config.HatTypeId != HatTypeId.None)
                _inventoryService.AddHat(config.HatTypeId);
            
            _saveLoadService.SavePrograss();


        }


        public void Read(PlayerProgress playerProgress) =>
            _purchasedItems = playerProgress.PruchasedItems;
        

        public void Write(PlayerProgress playerProgress) =>
            playerProgress.PruchasedItems = _purchasedItems;
    }
}