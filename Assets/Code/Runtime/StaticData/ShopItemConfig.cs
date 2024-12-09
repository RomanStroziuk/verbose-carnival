using Code.Runtime.Data;
using Code.Runtime.Gameplay.View.UI.Shop;
using UnityEngine;

namespace Code.Runtime.StaticData
{
    [CreateAssetMenu(fileName = "ShopItemConfig", menuName = "StaticData/ShopItemConfig")]
    public class ShopItemConfig : ScriptableObject
    {
       
        public string Name;
        public Sprite Sprite;
        public int Price;

        public ShopItemId ShopItemId;
        public HatTypeId HatTypeId;
        public JumpTypeId JumpTypeId;
    }

}