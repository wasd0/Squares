namespace Scripts.MonoBehaviours
{
    public class Damage : HealthHandler
    {
        public override void HandleHealth(ref float health)
        {
            health -= Amount;
        }
    }
}
