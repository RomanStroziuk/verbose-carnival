namespace Code.Runtime.Infrastructure.Services.WindowButtonsService
{
    public interface IWindowButtonsService
    {
        void PressPauseButton();
        void PressExitButton(string bootstrapSceneMenu);
        void PressRestartButton(string levelName);
        void PressResumeButton();
    }
}