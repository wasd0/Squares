using Resources.Data;
using Resources.Scripts.Models;
using Resources.Scripts.Presenters;
using Resources.Scripts.ScriptableObjects;
using Resources.Scripts.Views;
using UnityEngine;

namespace Resources.Scripts.MonoBehaviours
{
    public class GameCore : MonoBehaviour
    {
        [SerializeField]
        private PointView _pointView;

        [SerializeField]
        private SceneData _sceneData;

        [SerializeField]
        private PlayerStaticData _playerStaticData;
        
        private PointModel _pointModel;
        private PointPresenter _pointPresenter;

        private PlayerModel _playerModel;
        private PlayerView _playerView;
        private PlayerPresenter _playerPresenter;

        private void Awake()
        {
            InstantiatePlayer();
            Application.targetFrameRate = GameStaticData.FpsLimit;
            _pointModel = new PointModel();
            _pointPresenter = new PointPresenter(_pointModel, _pointView);
        }

        private void Update()
        {
            _pointPresenter.Update();
            _playerPresenter.Update();
        }

        private void LateUpdate()
        {
            _pointPresenter.LateUpdate();
            _playerPresenter.LateUpdate();
        }

        private void InstantiatePlayer()
        {
            Vector2 spawnPos = _sceneData.PlayerSpawn.position;
            _playerView = Instantiate(_playerStaticData.PlayerPrefab, spawnPos, Quaternion.identity, null).
                GetComponent<PlayerView>();
            _playerModel = new PlayerModel(spawnPos, _playerStaticData.MovementSpeed);
            _playerPresenter = new PlayerPresenter(_playerModel, _playerView);
        }
    }
}
