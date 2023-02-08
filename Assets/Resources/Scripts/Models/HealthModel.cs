namespace Resources.Scripts.Models
{
    public delegate void HealthHandle(ref float health);

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

        public void SetHealth(HealthHandle healthHandle)
        {
            healthHandle.Invoke(ref _health);
            HealthChangedFlag = true;
        }
    }
}
