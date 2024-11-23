using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public sealed class Wallet : MonoBehaviour
    {
        [SerializeField]
        private int balance;

        
        public int Balance => balance;
        public void AddCoin()
        {
            balance++;
        }
        
    }
}