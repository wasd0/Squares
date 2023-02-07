using Resources.Scripts.MonoBehaviours;
using TMPro;
using UnityEngine;

namespace Resources.Scripts.Views
{
    public class HealthView : MonoBehaviour
    {
        private TMP_Text _healthText;
        
        public HealthHandler Handler { get; private set; }

        public void Init(TMP_Text healthText)
        {
            _healthText = healthText;
        }
        
        public void ResetHandler()
        {
            Handler = null;
        }

        public void SetHealth(float amount)
        {
            _healthText.text = amount.ToString();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Handler = other.gameObject.GetComponent<HealthHandler>();
        }
    }
}
