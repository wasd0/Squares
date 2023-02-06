using Resources.Scripts.Models;
using Resources.Scripts.Views;

namespace Resources.Scripts.Presenters
{
    public class PointPresenter
    {
        private readonly PointModel _model;
        private readonly PointView _view;

        public PointPresenter(PointModel model, PointView view)
        {
            _model = model;
            _view = view;
        }

        public void Update()
        {
            if (_view.Provider)
                _model.AddValue(_view.Provider.Points);
            if (_model.ValueChangedFlag)
                _view.SetPoints(_model.Value);
        }

        public void LateUpdate()
        {
            _model.ResetFlag();
            _view.ResetProvider();
        }
    }
}
