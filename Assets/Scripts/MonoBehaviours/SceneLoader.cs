using Scripts.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.MonoBehaviours
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
