using Resources.Scripts.Infrastructure;
using Resources.Scripts.Presenters;
using Resources.Scripts.ScriptableObjects;
using Resources.Scripts.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Resources.Scripts.MonoBehaviours
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField]
        private GameCore _core;

        [SerializeField]
        private SceneData _sceneData;

        [SerializeField]
        private Button _startButton;

        [SerializeField]
        private PlayerStaticData _playerData;

        private PlayerPresenter _player;
        private ScorePresenter _score;
        private HealthPresenter _health;
        private ItemSpawner _itemSpawner;

        public void Init()
        {
            var spawnPos = _sceneData.PlayerSpawn.position;
            var player = Instantiate(_playerData.PlayerPrefab, spawnPos, Quaternion.identity, null);
            var playerView = player.GetComponent<PlayerView>();
            var scoreView = player.GetComponent<ScoreView>();
            var healthView = player.GetComponent<HealthView>();


            _player = new PlayerPresenter(playerView, spawnPos, _playerData.MovementSpeed);
            _score = new ScorePresenter(scoreView);
            _health = new HealthPresenter(healthView, _playerData.Health);
            _itemSpawner = new ItemSpawner(_sceneData);
            _startButton.gameObject.SetActive(false);
            _core.gameObject.SetActive(true);

            scoreView.Init(_sceneData.ScoreText);
            healthView.Init(_sceneData.HealthText);
            _core.Init(_player, _score, _health, _itemSpawner);

            Destroy(gameObject);
        }
    }
}
