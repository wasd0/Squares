using Resources.Scripts.Models;
using Resources.Scripts.Presenters;
using Resources.Scripts.Views;

namespace Resources.Scripts.Applications
{
    public class ScoreApplication
    {
        private readonly ScorePresenter _presenter;

        public ScoreApplication(ScoreView view)
        {
            var scoreModel = new ScoreModel();
            _presenter = new ScorePresenter(scoreModel, view);
        }

        public void Update()
        {
            _presenter.Update();
        }

        public void LateUpdate()
        {
            _presenter.LateUpdate();
        }
    }
}
