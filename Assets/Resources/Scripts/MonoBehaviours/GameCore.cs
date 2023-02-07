using Resources.Data;
using Resources.Scripts.Applications;
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

        private ScoreApplication _scoreApplication;
        private PlayerApplication _playerApplication;
        private ItemApplication _itemApplication;
        private ItemApplication _obstacleApplication;
        private HealthApplication _healthApplication;
        private HealthView _healthView;
        private ItemView _itemView;
        private ItemView _obstacleView;
        private ScoreView _scoreView;

        private void Awake()
        {
            Application.targetFrameRate = GameStaticData.FpsLimit;
            InitializePlayer();
            InitializeItem();
            InitializeObstacle();
            _healthApplication = new HealthApplication(_playerData.Health, _healthView);
        }

        private void InitializePlayer()
        {
            var spawnPos = _sceneData.PlayerSpawn.position;
            var player = Instantiate(_playerData.PlayerPrefab, spawnPos, Quaternion.identity, null);
            var playerView = player.GetComponent<PlayerView>();
            _healthView = player.GetComponent<HealthView>();
            _healthView.Init(_sceneData.HealthText);
            _playerApplication = new PlayerApplication(playerView, spawnPos, _playerData.MovementSpeed);
        }

        private void InitializeObstacle()
        {
            Vector2 spawnPos = _sceneData.ItemSpawn.position;
            Vector2 endPos = _sceneData.ItemEndPoint.position;
            var obstacle = Instantiate(_sceneData.ObstaclePrefab, spawnPos, Quaternion.identity, null);
            
            _obstacleView = obstacle.GetComponent<ItemView>();
            _obstacleApplication = new ItemApplication(_obstacleView, spawnPos, endPos, _sceneData.ItemsFallMultiplier);
        }

        private void InitializeItem()
        {
            Vector2 spawnPos = _sceneData.ItemSpawn.position;
            Vector2 endPos = _sceneData.ItemEndPoint.position;
            var item = Instantiate(_sceneData.ItemPrefab, spawnPos, Quaternion.identity, null);
            
            _itemView = item.GetComponent<ItemView>();
            _scoreView = item.GetComponent<ScoreView>();
            _scoreView.Init(_sceneData.ScoreText);
            _itemApplication = new ItemApplication(_itemView, spawnPos, endPos, _sceneData.ItemsFallMultiplier);
            _scoreApplication = new ScoreApplication(_scoreView);
        }

        private void Update()
        {
            _scoreApplication.Update();
            _playerApplication.Update();
            _itemApplication.Update();
            _obstacleApplication.Update();
            _healthApplication.Update();
        }

        private void LateUpdate()
        {
            _scoreApplication.LateUpdate();
            _playerApplication.LateUpdate();
            _itemApplication.LateUpdate();
            _obstacleApplication.LateUpdate();
            _healthApplication.LateUpdate();
        }
    }
}
