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
        private PointsView _pointsView;

        [SerializeField]
        private SceneData _sceneData;

        [SerializeField]
        private PlayerStaticData _playerStaticData;


        private PointsModel _pointsModel;
        private PointsPresenter _pointsPresenter;

        private PlayerModel _playerModel;
        private PlayerView _playerView;
        private PlayerPresenter _playerPresenter;

        private void Awake()
        {
            InstantiatePlayer();
            _pointsModel = new PointsModel();
            _pointsPresenter = new PointsPresenter(_pointsModel, _pointsView);
        }

        private void InstantiatePlayer()
        {
            Vector2 spawnPos = _sceneData.PlayerSpawn.position;
            _playerView = Instantiate(_playerStaticData.PlayerPrefab, spawnPos, Quaternion.identity, null).
                GetComponent<PlayerView>();
            _playerModel = new PlayerModel(spawnPos, _playerStaticData.MovementSpeed);
            _playerPresenter = new PlayerPresenter(_playerModel, _playerView);
        }

        private void Update()
        {
            _pointsPresenter.Update();
            _playerPresenter.Update();
        }

        private void LateUpdate()
        {
            _pointsPresenter.LateUpdate();
            _playerPresenter.LateUpdate();
        }
    }
}
