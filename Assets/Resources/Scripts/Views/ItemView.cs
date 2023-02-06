using UnityEngine;

namespace Resources.Scripts.Views
{
    public class ItemView : MonoBehaviour
    {
        private float _positionY;

        [SerializeField]
        private GameObject _itemPrefab;

        public float PositionY
        {
            get
            {
                _positionY = _itemPrefab.transform.position.y;
                return _positionY;
            }
        }

        public void SetPosition(Vector2 position)
        {
            _itemPrefab.transform.position = position;
        }

        public void ResetPosition()
        {
            _positionY = 0f;
        }
    }
}
