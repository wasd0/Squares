using UnityEngine;

namespace Resources.Scripts.Models
{
    public class ItemModel
    {
        public Vector2 Position { get; private set; }
        private readonly Vector2 _endPosition;

        public bool PositionChangedFlag { get; private set; } = true;

        public bool PositionFinishedFlag { get; private set; }

        public ItemModel(Vector2 startPosition, Vector2 endPosition)
        {
            Position = startPosition;
            _endPosition = endPosition;
        }

        public void AccelerateFall(float gravitation, float multiplier, float deltaTime)
        {
            if (Position.y <= _endPosition.y)
            {
                PositionFinishedFlag = true;
                return;
            }

            float newY = Position.y + gravitation * multiplier * deltaTime;
            Position = new Vector2(Position.x, newY);
            PositionChangedFlag = true;
        }

        public void ResetFlag()
        {
            PositionChangedFlag = false;
            PositionFinishedFlag = false;
        }
    }
}
