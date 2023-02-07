using Resources.Scripts.Models;
using Resources.Scripts.Presenters;
using Resources.Scripts.Views;
using UnityEngine;

namespace Resources.Scripts.Applications
{
    public class ItemApplication
    {
        private readonly ItemPresenter _presenter;

        public ItemApplication(ItemView view, Vector2 spawn, Vector2 end, float fallMultiplier)
        {
            var model = new ItemModel(spawn, end);
            _presenter = new ItemPresenter(model, view, fallMultiplier);
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
