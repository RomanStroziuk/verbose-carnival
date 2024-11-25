using Code.Runtime.Data;

namespace Code.Runtime.Infrastructure.SaveLoad
{
    public interface IWriteProgress
    {
        public void Write(PlayerProgress playerProgress);
    }
}