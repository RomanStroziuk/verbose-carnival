using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

        public void UpdateView(Sprite sprite, string name, int price)
        {
            _Image.sprite = sprite;
            _name.text = name;
            _price.text = price.ToString();
        }
    }
}