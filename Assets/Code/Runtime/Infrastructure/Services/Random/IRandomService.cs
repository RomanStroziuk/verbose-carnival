using System.Collections.Generic;
using UnityEngine;

namespace Code.Runtime.Infrastructure.Services.Random
{
    public interface IRandomService
    {
        float Range(float minInclusive, float maxInclusive);
        T ChooseFromList<T>(List<T> collection);
    }
}