using Scripts.Data;
using Scripts.Models;
using Scripts.Views;
using UnityEngine;

namespace Scripts.Presenters
{
    public class ItemPresenter
    {
        private readonly ItemModel _model;
        private readonly ItemView _view;
        private readonly float _fallMultiplier;

        public ItemPresenter(ItemView view, Vector2 start, Vector2 end, float fallMultiplier)
        {
            _model = new ItemModel(start, end);
            _view = view;
            _fallMultiplier = fallMultiplier;
        }

        public void Reset(Vector2 spawn, Vector2 end)
        {
            _model.ResetPosition(spawn, end);
            _view.gameObject.SetActive(true);
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
