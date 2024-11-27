using System;
using System.Collections.Generic;
using Code.Runtime.Infrastructure.Services.StaticData;
using Code.Runtime.StaticData;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.View.UI.Shop
{
    internal sealed class Shop : MonoBehaviour
    {
        
        [SerializeField] private ShopItem _shopItemPrefab;
        
        private readonly List<ShopItem> _shopItems = new();
        private IStaticDataService _staticDataService;
        private IInstantiator _instantiator;

        [SerializeField] private Transform _contentContainer;

        [Inject]
        private void Construct([CanBeNull] IStaticDataService staticDataService, IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _staticDataService = staticDataService;

        }

        private void Start()
        {
            IEnumerable<HatConfig> hatsConfigs = _staticDataService.GetHatsConfigs();
            foreach (HatConfig config in hatsConfigs)
            {
               ShopItem  shopItem = _instantiator.InstantiatePrefabForComponent<ShopItem>(_shopItemPrefab, _contentContainer);
               _shopItems.Add(shopItem);
               shopItem.Bought += onBought;
               shopItem.UpdateView(config.Sprite, config.Name, config.Price, config.HatTypeId);

            }
        }
        
        private void onBought() =>
            UpdateShopItemsView();

        private void UpdateShopItemsView()
        {
            foreach (ShopItem shopItem in _shopItems)
            {
                HatConfig config = _staticDataService.GetHatConfig(shopItem.HatType);
                shopItem.UpdateView(config.Sprite, config.Name, config.Price, config.HatTypeId);

            }

        }

        
    }
}