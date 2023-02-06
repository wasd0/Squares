using Resources.Scripts.MonoBehaviours;
using TMPro;
using UnityEngine;

namespace Resources.Scripts.Views
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _pointsText;

        public PointsProvider Provider { get; private set; }

        public void ResetProvider()
        {
            Provider = null;
        }

        public void SetPoints(int amount)
        {
            _pointsText.text = amount.ToString();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Provider = other.gameObject.GetComponent<PointsProvider>();
        }
    }
}