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
        [FormerlySerializedAs("OwnedItems")] 
        public List<ShopItemId> PruchasedItems = new();

        public List<HatTypeId> OwnedHats = new();
        public List<JumpTypeId> OwnedJumps = new();
        public HatTypeId SelectedHat = HatTypeId.None;
        public JumpTypeId SelectedJump = JumpTypeId.None;
    }
}