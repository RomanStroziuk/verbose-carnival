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
        
        public T ChooseWeighted<T>(List<(T Item, int Weight)> items)
        {
            if (items == null || items.Count == 0)
                return default;
            int totalWeight = 0;
            foreach (var (_, weight) in items)
                totalWeight += weight;
            int randomPoint = UnityEngine.Random.Range(0, totalWeight);
            foreach (var (item, weight) in items)
            {   
                if (randomPoint < weight)
                    return item;
                randomPoint -= weight;
            }
            return default;
        }
    }
}