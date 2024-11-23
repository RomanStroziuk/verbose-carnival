namespace Code.Runtime.Infrastructure.Services.Random
{
    public interface IRandomService
    {
        float Range(float minInclusive, float maxInclusive);
    }
}