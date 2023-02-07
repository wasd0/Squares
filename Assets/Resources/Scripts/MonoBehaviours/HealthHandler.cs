using UnityEngine;

namespace Resources.Scripts.MonoBehaviours
{
    public abstract class HealthHandler : MonoBehaviour
    {
        [SerializeField]
        private float _amount;

        public float Amount => _amount;

        public abstract void HandleHealth(ref float health);
    }
}
