using Resources.Scripts.Models;
using Resources.Scripts.Views;
using UnityEngine;

namespace Resources.Scripts.Presenters
{
    public class PlayerPresenter
    {
        private readonly PlayerModel _model;
        private readonly PlayerView _view;

        public PlayerPresenter(PlayerView view, Vector2 start, float movementSpeed)
        {
            _model = new PlayerModel(start, movementSpeed);
            _view = view;
        }

        public void Update()
        {
            _model.Accelerate((int) _view.HorizontalAxis, Time.deltaTime);
            if (_model.PositionChangedFlag)
                _view.SetPosition(_model.Position);
        }

        public void LateUpdate()
        {
            _model.ResetFlag();
            _view.ResetAxis();
        }
    }
}
