using Code.Runtime.Data;
using Code.Runtime.Infrastructure.SaveLoad;

namespace Code.Runtime.Infrastructure.Services.Shop
{
    public interface IShopService : IReadProgress, IWriteProgress
    {
        bool CanBuyItem(HatTypeId hatType);
        void BuyItem(HatTypeId hatType);
    }
}