using UnityEngine;

namespace Resources.Scripts.Views
{
    public class PlayerView : MonoBehaviour
    {
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
            transform.position = position;
        }

        public void ResetAxis()
        {
            _horizontalAxis = 0f;
        }
    }
}
