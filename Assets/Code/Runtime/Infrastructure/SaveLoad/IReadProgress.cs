using Code.Runtime.Data;

namespace Code.Runtime.Infrastructure.SaveLoad
{
    public interface IReadProgress
    {
        public void Read(PlayerProgress playerProgress);
    }
}