using UnityEngine;

namespace Resources.Scripts.Views
{
    public class PlayerView : MonoBehaviour
    {
        public float HorizontalAxis { get; private set; }

        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }
        
        private void Update()
        {
            HorizontalAxis = Input.GetAxis("Horizontal");
        }
    }
}
