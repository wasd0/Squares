using Resources.Scripts.Models;
using Resources.Scripts.Views;

namespace Resources.Scripts.Presenters
{
    public class PointsPresenter
    {
        private readonly PointsModel _model;
        private readonly PointsView _view;

        public PointsPresenter(PointsModel model, PointsView view)
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
