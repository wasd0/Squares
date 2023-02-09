using Resources.Scripts.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Resources.Scripts.MonoBehaviours
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadLevel()
        {
            SceneManager.LoadScene(GameStaticData.LevelSceneIndex);
        }

        public void LoadMenu()
        {
            SceneManager.LoadScene(GameStaticData.MainSceneIndex);
        }
    }
}
