using UnityEngine;

namespace Scripts.Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField]
        private GameObject _playerPrefab;

        private readonly int _screenHalf = Screen.width / 2;
        private float _horizontalAxis;

        public float HorizontalAxis
        {
            get
            {
                _horizontalAxis = Input.touchCount > 0 ? Input.GetTouch(0).position.x : 0f;
                
                if (_horizontalAxis == 0)
                    return _horizontalAxis;
                if (_horizontalAxis >= _screenHalf)
                    return 1;
                
                return -1;
            }
            private set
            {
                _horizontalAxis = value;
            }
        }

        public void SetPosition(Vector2 position)
        {
            _playerPrefab.transform.position = position;
        }

        public void ResetAxis()
        {
            HorizontalAxis = 0f;
        }
    }
}
