namespace Code.Runtime.Infrastructure.Services.Random
{
    public class RandomService : IRandomService
    {
        public float Range(float minInclusive, float maxInclusive)
        {
            return UnityEngine.Random.Range(minInclusive, maxInclusive);
        }
    }
}