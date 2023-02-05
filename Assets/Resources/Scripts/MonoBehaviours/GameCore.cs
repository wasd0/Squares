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
        private PlayerView _playerView;

        [SerializeField]
        private SceneData _sceneData;

        [SerializeField]
        private PlayerStaticData _playerStaticData;

        private PointsPresenter _pointsPresenter;
        private PointsModel _pointsModel;

        private PlayerModel _playerModel;
        private PlayerPresenter _playerPresenter;

        private void Awake()
        {
            _pointsModel = new PointsModel();
            _pointsPresenter = new PointsPresenter(_pointsModel, _pointsView);

            _playerModel = new PlayerModel(_sceneData.PlayerSpawn.position, _playerStaticData.MovementSpeed);
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
