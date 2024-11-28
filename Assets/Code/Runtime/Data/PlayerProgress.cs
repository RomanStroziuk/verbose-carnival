using System;
using System.Collections.Generic;
using Code.Runtime.Gameplay.View.UI.Shop;
using UnityEngine.Serialization;

namespace Code.Runtime.Data
{
    [Serializable]
    public sealed class PlayerProgress
    {
        public int Coins;
        [FormerlySerializedAs("OwnedHats")] 
        public List<ShopItemId> PruchasedItems = new();

        public List<HatTypeId> OwnedHats = new();
        public HatTypeId SelectedHat = HatTypeId.None;
    }
}