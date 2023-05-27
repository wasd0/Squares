using UnityEngine;

namespace Scripts.MonoBehaviours
{
    public abstract class HealthHandler : MonoBehaviour
    {
        [SerializeField]
        private float _amount;

        protected float Amount => _amount;

        public abstract void HandleHealth(ref float health);
    }
}
