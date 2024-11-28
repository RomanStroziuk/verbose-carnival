using Code.Runtime.Data;
using Code.Runtime.Infrastructure.SaveLoad;

namespace Code.Runtime.Infrastructure.Services.PlayerInventory
{
    public interface IPlayerInventoryService : IReadProgress, IWriteProgress
    {
        void AddHat(HatTypeId hatTypeId);

        bool HasEnyHat { get; }
        HatTypeId SelectedHat { get; }
    }
}