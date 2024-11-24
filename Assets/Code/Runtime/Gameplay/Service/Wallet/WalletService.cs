using UnityEngine;

namespace Code.Runtime.Gameplay.Service.Wallet
{
    public sealed class WalletService : IWalletService
    {
        private int balance;

        
        public int Balance => balance;
        public void AddCoin()
        {
            balance++;
        }
        
    }
}