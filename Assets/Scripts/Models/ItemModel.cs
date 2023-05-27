using UnityEngine;

namespace Scripts.Models
{
    public class ItemModel
    {
        private Vector2 _endPosition;
        
        public Vector2 Position { get; private set; }
        public bool PositionChangedFlag { get; private set; } = true;
        public bool PositionFinishedFlag { get; private set; }

        public ItemModel(Vector2 start, Vector2 end)
        {
            Position = start;
            _endPosition = end;
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

        public void ResetPosition(Vector2 start, Vector2 end)
        {
            Position = start;
            _endPosition = end;
        }

        public void ResetFlag()
        {
            PositionChangedFlag = false;
            PositionFinishedFlag = false;
        }
    }
}
