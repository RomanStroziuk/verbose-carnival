using Code.Runtime.Data;

namespace Code.Runtime.Infrastructure.WindowsService
{
    public interface IWindowService
    {
        void OpenWindow(WindowTypeId windowTypeId);
        void CloseWindow();
    }
}