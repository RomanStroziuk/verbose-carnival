using System.Collections.Generic;
using Code.Runtime.Data;
using Code.Runtime.Infrastructure.SaveLoad;

namespace Code.Runtime.Infrastructure.Services.PlayerInventory
{
    public sealed class PlayerInventoryService : IPlayerInventoryService 
    {
        private List<HatTypeId> _hats;

        public void AddHat(HatTypeId hatTypeId) =>
            _hats.Add(hatTypeId);

        public void Read(PlayerProgress playerProgress)=>
            _hats = playerProgress.OwnedHats;
        

        public void Write(PlayerProgress playerProgress)=>
            playerProgress.OwnedHats = _hats;
        
    }
}