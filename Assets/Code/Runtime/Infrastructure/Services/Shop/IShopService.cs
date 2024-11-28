using Code.Runtime.Data;
using Code.Runtime.Gameplay.View.UI.Shop;
using Code.Runtime.Infrastructure.SaveLoad;

namespace Code.Runtime.Infrastructure.Services.Shop
{
    public interface IShopService : IReadProgress, IWriteProgress
    {
        bool CanBuyItem(ShopItemId hatType);
        void BuyItem(ShopItemId hatType);
    }
}