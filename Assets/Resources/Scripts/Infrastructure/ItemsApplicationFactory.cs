using Resources.Scripts.Applications;
using Resources.Scripts.Views;
using UnityEngine;

namespace Resources.Scripts.Infrastructure
{
    public class ItemsApplicationFactory
    {
        private readonly Vector2 _itemEndPoint;
        private readonly float _fallMultiply;

        public ItemsApplicationFactory(Vector2 itemEndPoint, float fallMultiply)
        {
            _itemEndPoint = itemEndPoint;
            _fallMultiply = fallMultiply;
        }

        public ItemApplication Create(GameObject instance, Vector2 spawn)
        {
            var view = instance.GetComponent<ItemView>();
            return new ItemApplication(view, spawn, _itemEndPoint, _fallMultiply);
        }
    }
}
