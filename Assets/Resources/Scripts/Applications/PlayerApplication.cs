using Resources.Scripts.Models;
using Resources.Scripts.Presenters;
using Resources.Scripts.Views;
using UnityEngine;

namespace Resources.Scripts.Applications
{
    public class PlayerApplication
    {
        private readonly PlayerPresenter _presenter;

        public PlayerApplication(PlayerView view, Vector2 spawn, float movementSpeed)
        {
            var  model = new PlayerModel(spawn, movementSpeed);
            _presenter = new PlayerPresenter(model, view);
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
