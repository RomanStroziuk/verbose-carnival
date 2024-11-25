using Code.Runtime.Data;
using Code.Runtime.Infrastructure.SaveLoad;
using UnityEngine;

namespace Code.Runtime.Gameplay.Service.Wallet
{
    public sealed class WalletService : IWalletService, IWriteProgress, IReadProgress
    {
        private int _balance;


        public int Balance => _balance;

        public void AddCoin()
        {
            _balance++;
        }

        public void Write(PlayerProgress playerProgress)
        {
            playerProgress.Coins = _balance;
        }

        public void Read(PlayerProgress playerProgress)
        {
            _balance = playerProgress.Coins;
        }
    }
}