using Code.Runtime.Data;
using Code.Runtime.Infrastructure.SaveLoad;

namespace Code.Runtime.Infrastructure.Services.SaveLoad
{
    internal interface ISaveLoadService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}