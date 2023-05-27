using UnityEngine;

namespace Scripts.Models
{
    public class PlayerModel
    {
        private readonly float _movementSpeed;
        private readonly float _minX;
        private readonly float _maxX;
        public Vector2 Position { get; private set; }
        public bool PositionChangedFlag { get; private set; } = true;

        public PlayerModel(Vector2 startPosition, float movementSpeed, float minX, float maxX)
        {
            Position = startPosition;
            _movementSpeed = movementSpeed;
            _maxX = maxX;
            _minX = minX;
        }

        public void ResetFlag()
        {
            PositionChangedFlag = false;
        }

        public void Accelerate(float axis, float deltaTime)
        {
            float newX = Position.x + axis * _movementSpeed * deltaTime;
            newX = Mathf.Clamp(newX, _minX, _maxX);
            Position = new Vector2(newX, Position.y);
            PositionChangedFlag = true;
        }
    }
}
