using Resources.Scripts.Models;
using Resources.Scripts.Views;
using UnityEngine;

namespace Resources.Scripts.Presenters
{
    public class PlayerPresenter
    {
        private readonly PlayerModel _model;
        private readonly PlayerView _view;

        public PlayerPresenter(PlayerModel model, PlayerView view)
        {
            _model = model;
            _view = view;
        }

        public void Update()
        {
            if (_view.HorizontalAxis != 0)
                _model.AddPosition(_view.HorizontalAxis, Time.deltaTime);
            if (_model.OnPositionChanged)
                _view.SetPosition(_model.Position);
        }

        public void LateUpdate()
        {
            _model.UpdateState();
        }
    }
}
