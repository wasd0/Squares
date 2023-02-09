using Resources.Scripts.Data;
using Resources.Scripts.Infrastructure;
using Resources.Scripts.Presenters;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Resources.Scripts.MonoBehaviours
{
    public class GameCore : MonoBehaviour
    {
        [SerializeField]
        private GameDataService _service;

        private ItemSpawner _itemSpawner;
        private GameDataStruct _data;
        private ScorePresenter _score;
        private PlayerPresenter _player;
        private HealthPresenter _health;

        public void Init(PlayerPresenter player, ScorePresenter score, HealthPresenter health, ItemSpawner spawner)
        {
            Application.targetFrameRate = GameStaticData.FpsLimit;
            _service.Init();
            _data = _service.LoadFromJSON();
            _player = player;
            _score = score;
            _health = health;
            _itemSpawner = spawner;
            StartCoroutine(_itemSpawner.Spawn());
        }

        private void EndGame()
        {
            SaveGame();
            SceneManager.LoadScene(GameStaticData.LoseSceneIndex);
        }

        private void SaveGame()
        {
            _data.LastScore = _score.LastScore;
            if (_data.HighScore < _score.LastScore)
                _data.HighScore = _score.LastScore;
            _data.AudioVolume = 1;
            _service.SaveToJSON(_data);
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
                EndGame();
        }
    }
}
