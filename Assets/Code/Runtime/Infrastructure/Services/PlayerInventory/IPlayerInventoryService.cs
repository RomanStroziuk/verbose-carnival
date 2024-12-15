using Code.Runtime.Data;
using Code.Runtime.Infrastructure.SaveLoad;

namespace Code.Runtime.Infrastructure.Services.PlayerInventory
{
    public interface IPlayerInventoryService : IReadProgress, IWriteProgress
    {
        void AddHat(HatTypeId hatTypeId);
        void AddJumpType(JumpTypeId jumpTypeId);
        void SelectJump(JumpTypeId jumpTypeId);

        bool HasAnyHat { get; }
        bool HasAnyJump { get; }
        HatTypeId SelectedHat { get; }
        JumpTypeId SelectedJump { get; }
        void SelectNextHat();
        void SelectNextJump();
    }
}