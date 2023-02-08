using Resources.Data;
using Resources.Scripts.Models;
using Resources.Scripts.Views;
using UnityEngine;

namespace Resources.Scripts.Presenters
{
    public class ItemPresenter
    {
        private readonly ItemModel _model;
        private readonly ItemView _view;
        private readonly float _fallMultiplier;

        public ItemPresenter(ItemModel model, ItemView view, float fallMultiplier)
        {
            _model = model;
            _view = view;
            _fallMultiplier = fallMultiplier;
        }

        public void Update()
        {
            if (!_model.PositionFinishedFlag)
                _model.AccelerateFall(GameStaticData.Gravitation, _fallMultiplier, Time.deltaTime);
            if (_model.PositionChangedFlag)
                _view.SetPosition(_model.Position);
        }

        public void LateUpdate()
        {
            _model.ResetFlag();
        }
    }
}
