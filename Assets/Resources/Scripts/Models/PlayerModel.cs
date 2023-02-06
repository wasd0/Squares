using UnityEngine;

namespace Resources.Scripts.Models
{
    public class PlayerModel : IModel
    {
        private readonly float _speed;
        
        public Vector2 Position { get; private set; }
        public bool PositionChangedFlag { get; private set; } = true;

        public PlayerModel(Vector2 startPosition, float speed)
        {
            Position = startPosition;
            _speed = speed;
        }

        public void ResetFlag()
        {
            PositionChangedFlag = false;
        }

        public void SetPosition(float axis, float deltaTime)
        {
            float newX = Position.x + axis * _speed * deltaTime;
            Position = new Vector2(newX, Position.y);
            PositionChangedFlag = true;
        }
    }
}
