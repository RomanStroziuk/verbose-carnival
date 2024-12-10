using System;
using System.Collections.Generic;
using Code.Runtime.Data;

namespace Code.Runtime.Infrastructure.Services.PlayerInventory
{
    internal sealed class PlayerInventoryService : IPlayerInventoryService 
    {
        private List<HatTypeId> _hats = new();
        private List<JumpTypeId> _jumpTypeId = new();
        
        public HatTypeId SelectedHat { get; private set; }
        public JumpTypeId SelectedJump { get; private set; }
        
        public bool HasAnyHat => _hats.Count > 0;
        public bool HasAnyJump => _jumpTypeId.Count > 0;
        
        public void AddHat(HatTypeId hatTypeId) =>
            _hats.Add(hatTypeId);
        public void AddJumpType(JumpTypeId jumpTypeId) =>
            _jumpTypeId.Add(jumpTypeId);

        public void Read(PlayerProgress playerProgress)
        {
            _hats = playerProgress.OwnedHats;
            _jumpTypeId = playerProgress.OwnedJumps;
            SelectedHat = playerProgress.SelectedHat;
            SelectedJump = playerProgress.SelectedJump;
        }

        public void Write(PlayerProgress playerProgress)
        {
            playerProgress.OwnedHats = _hats;
            playerProgress.OwnedJumps = _jumpTypeId;
            playerProgress.SelectedHat = SelectedHat;
            playerProgress.SelectedJump = SelectedJump;
        }
        public void SelectJump(JumpTypeId jumpTypeId)
        {
            if (!_jumpTypeId.Contains(jumpTypeId))
                throw new InvalidOperationException("Jump type not available in inventory");

            SelectedJump = jumpTypeId;
        }

        public void SelectNextHat()
        {
            int findIndex = _hats.FindIndex(x => x == SelectedHat);

            if (findIndex < _hats.Count - 1)
                SelectedHat = _hats[findIndex + 1];
            else
                SelectedHat = HatTypeId.None;
        }
        public void SelectNextJump()
        {
            int findIndex = _jumpTypeId.FindIndex(x => x == SelectedJump);

            if (findIndex < _jumpTypeId.Count - 1)
                SelectedJump = _jumpTypeId[findIndex + 1];
            else
                SelectedJump = JumpTypeId.None;
        }
        
    }
}