using Code.Runtime.Data;

namespace Code.Runtime.Infrastructure.Services.Progress
{
    internal sealed class ProgressService : IProgressService
    {
        public PlayerProgress PlayerProgress { get; set; }
    }
}