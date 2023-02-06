using UnityEngine;

namespace Resources.Scripts.Models
{
    public class PlayerModel : IModel
    {
        private readonly float _movementSpeed;
        
        public Vector2 Position { get; private set; }
        public bool PositionChangedFlag { get; private set; } = true;

        public PlayerModel(Vector2 startPosition, float movementSpeed)
        {
            Position = startPosition;
            _movementSpeed = movementSpeed;
        }

        public void ResetFlag()
        {
            PositionChangedFlag = false;
        }

        public void Accelerate(float axis, float deltaTime)
        {
            float newX = Position.x + axis * _movementSpeed * deltaTime;
            Position = new Vector2(newX, Position.y);
            PositionChangedFlag = true;
        }
    }
}
