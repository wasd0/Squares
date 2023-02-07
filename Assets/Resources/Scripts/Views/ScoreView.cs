using Resources.Scripts.MonoBehaviours;
using TMPro;
using UnityEngine;

namespace Resources.Scripts.Views
{
    public class ScoreView : MonoBehaviour
    {
        private TMP_Text _scoreText;

        public PointsProvider Provider { get; private set; }

        public void Init(TMP_Text scoreText)
        {
            _scoreText = scoreText;
        }
        
        public void  ResetProvider()
        {
            Provider = null;
        }

        public void SetPoints(int amount)
        {
            _scoreText.text = amount.ToString();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Provider = other.gameObject.GetComponent<PointsProvider>();
        }
    }
}