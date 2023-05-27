using Scripts.Models;
using Scripts.Views;
using UnityEngine;

namespace Scripts.Presenters
{
    public class PlayerPresenter
    {
        private readonly PlayerModel _model;
        private readonly PlayerView _view;

        public PlayerPresenter(PlayerView view, Vector2 start, float movementSpeed, float minX, float maxX)
        {
            _model = new PlayerModel(start, movementSpeed, minX, maxX);
            _view = view;
        }

        public void Update()
        {
            _model.Accelerate(_view.HorizontalAxis, Time.deltaTime);
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
