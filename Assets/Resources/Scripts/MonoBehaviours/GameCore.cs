using Resources.Data;
using Resources.Scripts.Infrastructure;
using Resources.Scripts.Presenters;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Resources.Scripts.MonoBehaviours
{
    public class GameCore : MonoBehaviour
    {
        private ItemSpawner _itemSpawner;
        private ScorePresenter _score;
        private PlayerPresenter _player;
        private HealthPresenter _health;

        public void Init(PlayerPresenter player, ScorePresenter score, HealthPresenter health, ItemSpawner spawner)
        {
            Application.targetFrameRate = GameStaticData.FpsLimit;
            _player = player;
            _score = score;
            _health = health;
            _itemSpawner = spawner;
            StartCoroutine(_itemSpawner.Spawn());
        }

        private void LoadLoseScene()
        {
            _player = null;
            _score = null;
            _health = null;
            _itemSpawner = null;
            SceneManager.LoadScene(GameStaticData.LoseSceneIndex);
        }

        private void Update()
        {
            _score.Update();
            _player.Update();
            _health.Update();
            _itemSpawner.Update();
        }

        private void LateUpdate()
        {
            _score.LateUpdate();
            _player.LateUpdate();
            _health.LateUpdate();
            _itemSpawner.LateUpdate();
            if (_itemSpawner.AllSpawnedFlag)
                StartCoroutine(_itemSpawner.Respawn());
            if (_health.HealthIsNullFlag)
                LoadLoseScene();
        }
    }
}
