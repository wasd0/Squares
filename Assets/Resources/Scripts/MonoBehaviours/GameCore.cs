using Resources.Data;
using Resources.Scripts.Applications;
using Resources.Scripts.Infrastructure;
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
        private ScoreApplication _scoreApplication;
        private PlayerApplication _playerApplication;
        private HealthApplication _healthApplication;

        private void Awake()
        {
            Application.targetFrameRate = GameStaticData.FpsLimit;
            _itemSpawner = new ItemSpawner(_sceneData);
            StartCoroutine(_itemSpawner.StartSpawn());
            InitializePlayer();
        }

        private void InitializePlayer()
        {
            var spawnPos = _sceneData.PlayerSpawn.position;
            var player = Instantiate(_playerData.PlayerPrefab, spawnPos, Quaternion.identity, null);
            var playerView = player.GetComponent<PlayerView>();
            var scoreView = player.GetComponent<ScoreView>();
            scoreView.Init(_sceneData.ScoreText);
            var healthView = player.GetComponent<HealthView>();
            healthView.Init(_sceneData.HealthText);
            _scoreApplication = new ScoreApplication(scoreView);
            _healthApplication = new HealthApplication(_playerData.Health, healthView);
            _playerApplication = new PlayerApplication(playerView, spawnPos, _playerData.MovementSpeed);
        }

        private void Update()
        {
            _scoreApplication.Update();
            _playerApplication.Update();
            _healthApplication.Update();
            _itemSpawner.Update();
        }

        private void LateUpdate()
        {
            _scoreApplication.LateUpdate();
            _playerApplication.LateUpdate();
            _healthApplication.LateUpdate(); 
            _itemSpawner.LateUpdate();
        }
    }
}
