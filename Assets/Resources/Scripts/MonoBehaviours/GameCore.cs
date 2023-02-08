using Resources.Data;
using Resources.Scripts.Infrastructure;
using Resources.Scripts.Presenters;
using Resources.Scripts.ScriptableObjects;
using Resources.Scripts.Views;
using UnityEngine;

namespace Resources.Scripts.MonoBehaviours
{
    public class GameCore : MonoBehaviour
    {
        [SerializeField]
        private SceneData _sceneData;

        [SerializeField]
        private PlayerStaticData _playerData;

        private ItemSpawner _itemSpawner;
        private ScorePresenter _score;
        private PlayerPresenter _player;
        private HealthPresenter _health;

        private void Awake()
        {
            Application.targetFrameRate = GameStaticData.FpsLimit;
            _itemSpawner = new ItemSpawner(_sceneData);
            StartCoroutine(_itemSpawner.Spawn());
            InitializePlayer();
        }

        private void InitializePlayer()
        {
            var spawnPos = _sceneData.PlayerSpawn.position;
            var player = Instantiate(_playerData.PlayerPrefab, spawnPos, Quaternion.identity, null);
            var playerView = player.GetComponent<PlayerView>();
            var scoreView = player.GetComponent<ScoreView>();
            var healthView = player.GetComponent<HealthView>();
            
            scoreView.Init(_sceneData.ScoreText);
            healthView.Init(_sceneData.HealthText);
            
            _score = new ScorePresenter(scoreView);
            _health = new HealthPresenter(healthView, _playerData.Health);
            _player = new PlayerPresenter(playerView, spawnPos, _playerData.MovementSpeed);
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
        }
    }
}
