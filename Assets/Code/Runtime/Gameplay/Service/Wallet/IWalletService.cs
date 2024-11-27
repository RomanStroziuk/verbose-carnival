using Code.Runtime.Infrastructure.SaveLoad;

namespace Code.Runtime.Gameplay.Service.Wallet
{
    public interface IWalletService : IWriteProgress, IReadProgress
    {
        int Balance { get; }
        void AddCoin();
        bool IsEnoughMoney(int configPrice);
        void Purchase(int price);
    }
}