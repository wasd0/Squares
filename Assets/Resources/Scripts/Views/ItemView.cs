using UnityEngine;

namespace Resources.Scripts.Views
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField]
        private GameObject _itemPrefab;

        public void SetPosition(Vector2 position)
        {
            _itemPrefab.transform.position = position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            gameObject.SetActive(false);
        }
    }
}
