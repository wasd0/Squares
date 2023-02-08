using Resources.Data;
using Resources.Scripts.Infrastructure;
using Resources.Scripts.Presenters;
using UnityEngine;

namespace Resources.Scripts.MonoBehaviours
{
    public class GameCore : MonoBehaviour
    {
        private ItemSpawner _itemSpawner;
        private ScorePresenter _score;
        private PlayerPresenter _player;
        private HealthPresenter _health;
        private bool _initFlag;

        private void Awake()
        {
            Application.targetFrameRate = GameStaticData.FpsLimit;
        }

        public void Init(PlayerPresenter player, ScorePresenter score, HealthPresenter health, ItemSpawner spawner)
        {
            _player = player;
            _score = score;
            _health = health;
            _itemSpawner = spawner;
            StartCoroutine(_itemSpawner.Spawn());
            _initFlag = true;
        }

        private void Update()
        {
            if (!_initFlag) return;
            _score.Update();
            _player.Update();
            _health.Update();
            _itemSpawner.Update();
        }

        private void LateUpdate()
        {
            if (!_initFlag) return;
            _score.LateUpdate();
            _player.LateUpdate();
            _health.LateUpdate();
            _itemSpawner.LateUpdate();
            if (_itemSpawner.AllSpawnedFlag)
                StartCoroutine(_itemSpawner.Respawn());
        }
    }
}
