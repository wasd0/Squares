using Resources.Scripts.Presenters;
using Resources.Scripts.Views;
using UnityEngine;

namespace Resources.Scripts.Infrastructure
{
    public class ItemPresenterFactory
    {
        private readonly Vector2 _itemEndPoint;
        private readonly float _fallMultiply;

        public ItemPresenterFactory(Vector2 itemEndPoint, float fallMultiply)
        {
            _itemEndPoint = itemEndPoint;
            _fallMultiply = fallMultiply;
        }

        public ItemPresenter Create(GameObject instance, Vector2 spawn)
        {
            var view = instance.GetComponent<ItemView>();
            return new ItemPresenter(view, spawn, _itemEndPoint, _fallMultiply);
        }
    }
}
