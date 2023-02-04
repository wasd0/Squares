namespace Resources.Scripts.Models
{
    public class PointsModel
    {
        public int Value { get; private set; }
        public bool OnValueChanged { get; private set; }

        public void UpdateState()
        {
            OnValueChanged = false;
        }

        public void Add(int amount)
        {
            Value += amount;
            OnValueChanged = true;
        }
    }
}