using UnityEngine.SceneManagement;

namespace Code.Runtime.Infrastructure.Services.Scene
{
    public class SceneLoader : ISceneLoader
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}