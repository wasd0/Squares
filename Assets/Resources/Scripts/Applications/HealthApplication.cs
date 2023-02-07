using Resources.Scripts.Models;
using Resources.Scripts.Presenters;
using Resources.Scripts.Views;

namespace Resources.Scripts.Applications
{
    public class HealthApplication
    {
        private readonly HealthPresenter _presenter;

        public HealthApplication(float health, HealthView view)
        {
            var model = new HealthModel(health);
            _presenter = new HealthPresenter(model, view);
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
