using UnityEngine;

namespace Resources.Scripts.Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField]
        private GameObject _playerPrefab;
        
        private float _horizontalAxis;

        public float HorizontalAxis
        {
            get
            {
                _horizontalAxis = Input.touchCount > 0 ? Input.GetTouch(0).
                    deltaPosition.normalized.x : 0f;
                return _horizontalAxis;
            }
        }

        public void SetPosition(Vector2 position)
        {
            _playerPrefab.transform.position = position;
        }

        public void ResetAxis()
        {
            _horizontalAxis = 0f;
        }
    }
}
