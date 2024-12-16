using System;
using Code.Runtime.Infrastructure.Services.Shop;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace Code.Runtime.Gameplay.View.UI.Shop
{
    internal sealed class ShopItem : MonoBehaviour
    {
        [SerializeField]
        public Image _Image;

        [SerializeField] 
        private TextMeshProUGUI _name;

        [SerializeField]
        private TextMeshProUGUI _price;

        [SerializeField] private Button _buyButton;

        private void Awake() =>
            _buyButton.onClick.AddListener(Buy);
        
        private void OnDestroy() =>
            _buyButton.onClick.RemoveAllListeners();

        private IShopService _shopService;
        
        private ShopItemId _shopTypeId;
        public event Action Bought; 

        public ShopItemId ShopTypeId => _shopTypeId;

        [Inject]
        private void Construct(IShopService shopService) =>
            _shopService = shopService;
        
        public void UpdateView(Sprite sprite, string name, int price, ShopItemId hatType)
        {
            _Image.sprite = sprite;
            _name.text = name;
            _price.text = price.ToString();
            _shopTypeId = hatType;

            _buyButton.interactable = _shopService.CanBuyItem(_shopTypeId);
        }

        private void Buy()
        {
            _shopService.BuyItem(_shopTypeId);
            Bought?.Invoke();
        }
    }
}