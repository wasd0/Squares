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
        private ScoreView _scoreView;

        [SerializeField]
        private SceneData _sceneData;

        [SerializeField]
        private ItemView _itemView;

        [SerializeField]
        private PlayerStaticData _playerStaticData;

        private ScoreModel _scoreModel;
        private ScorePresenter _scorePresenter;

        private PlayerModel _playerModel;
        private PlayerView _playerView;
        private PlayerPresenter _playerPresenter;

        private ItemModel _itemModel;
        private ItemPresenter _itemPresenter;

        private void Awake()
        {
            InstantiatePlayer();
            Application.targetFrameRate = GameStaticData.FpsLimit;

            _scoreModel = new ScoreModel();
            _scorePresenter = new ScorePresenter(_scoreModel, _scoreView);

            _itemModel = new ItemModel(_sceneData.ItemSpawn.position, _sceneData.ItemEndPoint.position);
            _itemPresenter = new ItemPresenter(_itemModel, _itemView, _sceneData.ItemsFloatMultiplier);
        }

        private void Update()
        {
            _scorePresenter.Update();
            _playerPresenter.Update();
            _itemPresenter.Update();
        }

        private void LateUpdate()
        {
            _scorePresenter.LateUpdate();
            _playerPresenter.LateUpdate();
            _itemPresenter.LateUpdate();
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
