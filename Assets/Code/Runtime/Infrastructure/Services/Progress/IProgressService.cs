using Code.Runtime.Data;

namespace Code.Runtime.Infrastructure.Services.Progress
{
    internal interface IProgressService
    {
        PlayerProgress PlayerProgress { get; set; }
    }
}