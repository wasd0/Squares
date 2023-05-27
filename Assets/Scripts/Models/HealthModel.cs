namespace Scripts.Models
{
    public delegate void DamageHandler(ref float health);

    public class HealthModel
    {
        private float _health;
        public float Health => _health;
        public bool HealthChangedFlag { get; private set; } = true;

        public HealthModel(float health)
        {
            _health = health;
        }

        public void ResetFlag()
        {
            HealthChangedFlag = false;
        }

        public void SetHealth(DamageHandler damageHandler)
        {
            damageHandler.Invoke(ref _health);
            HealthChangedFlag = true;
        }
    }
}
