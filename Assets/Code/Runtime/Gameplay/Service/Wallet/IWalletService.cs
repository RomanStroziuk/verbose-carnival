namespace Code.Runtime.Gameplay.Service.Wallet
{
    public interface IWalletService
    {
        int Balance { get; }
        void AddCoin();
    }
}