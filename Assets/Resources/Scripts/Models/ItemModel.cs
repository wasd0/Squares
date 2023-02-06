using UnityEngine;

namespace Resources.Scripts.Models
{
    public class ItemModel : IModel
    {
        public Vector2 Position { get; private set; }
        public Vector2 EndPosition { get; }
        public bool PositionChangedFlag { get; private set; } = true;

        public ItemModel(Vector2 startPosition, Vector2 endPosition)
        {
            Position = startPosition;
            EndPosition = endPosition;
        }
        
        public void ResetFlag()
        {
            PositionChangedFlag = false;
        }

        public void AccelerateFall(float gravitation, float multiplier, float deltaTime)
        {
            float newY = Position.y + gravitation * multiplier * deltaTime;
            Position = new Vector2(Position.x, newY);
            PositionChangedFlag = true;
        }
    }
}
