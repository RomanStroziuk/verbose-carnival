using System.Collections.Generic;

namespace Code.Runtime.Infrastructure.Services.Random
{
    public interface IRandomService
    {
        float Range(float minInclusive, float maxInclusive);
        int RangeInt(int minInclusive, int maxInclusive);
        T ChooseFromList<T>(List<T> collection);
        T ChooseWeighted<T>(List<(T Item, int Weight)> items);
    }
}