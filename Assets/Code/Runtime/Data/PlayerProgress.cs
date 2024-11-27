using System;
using System.Collections.Generic;

namespace Code.Runtime.Data
{
    [Serializable]
    public sealed class PlayerProgress
    {
        public int Coins;
        public List<HatTypeId> OwnedHats = new();
    }
}