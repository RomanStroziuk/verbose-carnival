using System.Collections.Generic;

namespace Code.Runtime.Infrastructure.Services.Random
{
    public class RandomService : IRandomService
    {
        public float Range(float minInclusive, float maxInclusive)
        {
            return UnityEngine.Random.Range(minInclusive, maxInclusive);
        }

        public int RangeInt(int minInclusive, int maxInclusive)
        {
            return UnityEngine.Random.Range(minInclusive, maxInclusive);
        }
        
        public T ChooseFromList<T>(List<T> list)
        {
            if (list.Count == 0)
                return default;
            
            int index = UnityEngine.Random.Range(0, list.Count);
            return list[index];
        }
    }
}