using Code.Runtime.Infrastructure.SaveLoad;

namespace Code.Runtime.Gameplay.Service.Wallet
{
    public interface IWalletService : IWriteProgress, IReadProgress
    {
        int Balance { get; }
        void AddCoin();
    }
}