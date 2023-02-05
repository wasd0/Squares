using UnityEngine;

namespace Resources.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player", menuName = "Player Data")]
    public class PlayerStaticData : ScriptableObject
    {
        [Header("Movement")]
        [SerializeField]
        private float _movementSpeed;

        public float MovementSpeed => _movementSpeed;
    }
}
