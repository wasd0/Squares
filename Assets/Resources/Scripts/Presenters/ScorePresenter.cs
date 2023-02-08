using Resources.Scripts.Models;
using Resources.Scripts.Views;

namespace Resources.Scripts.Presenters
{
    public class ScorePresenter
    {
        private readonly ScoreModel _model;
        private readonly ScoreView _view;

        public ScorePresenter(ScoreView view)
        {
            _model = new ScoreModel();
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
