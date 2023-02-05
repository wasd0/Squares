using Resources.Scripts.MonoBehaviours;
using TMPro;
using UnityEngine;

namespace Resources.Scripts.Views
{
    public class PointsView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _pointsText;

        public PointsProvider Provider { get; private set; }

        public void UpdateState()
        {
            Provider = null;
        }

        public void SetPoints(int amount)
        {
            _pointsText.text = amount.ToString();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Provider = other.gameObject.GetComponent<PointsProvider>();
        }
    }
}