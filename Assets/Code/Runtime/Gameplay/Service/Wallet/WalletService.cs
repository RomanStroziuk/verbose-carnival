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

        public bool IsEnoughMoney(int configPrice) =>
            _balance >= configPrice;
        

        public void Write(PlayerProgress playerProgress)
        {
            playerProgress.Coins = _balance;
        }

        public void Read(PlayerProgress playerProgress)
        {
            _balance = playerProgress.Coins;
        }

        public void Purchase(int price)
        {
            if (!IsEnoughMoney(price))
                throw new System.InvalidOperationException("Not enough money");

            _balance -= price;
        }
    }
}