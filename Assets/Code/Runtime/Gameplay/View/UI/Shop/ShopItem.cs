using System;
using Code.Runtime.Data;
using Code.Runtime.Infrastructure.Services.Shop;
using Code.Runtime.StaticData;
using TMPro;
using Unity.VisualScripting;
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
        private HatTypeId _hatType;
        public event Action Bought; 

        public HatTypeId HatType => _hatType;

        [Inject]
        private void Construct(IShopService shopService) =>
            _shopService = shopService;
        
        public void UpdateView(Sprite sprite, string name, int price, HatTypeId hatType)
        {
            _Image.sprite = sprite;
            _name.text = name;
            _price.text = price.ToString();
            _hatType = hatType;

            _buyButton.interactable = _shopService.CanBuyItem(_hatType);
        }

        private void Buy()
        {
            _shopService.BuyItem(_hatType);
            Bought?.Invoke();
        }

       
    }
}