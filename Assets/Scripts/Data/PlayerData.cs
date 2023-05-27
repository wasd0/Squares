using UnityEngine;

namespace Scripts.Data
{
    [CreateAssetMenu(fileName = "Player", menuName = "Player Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Prefab")]
        [SerializeField]
        private GameObject _playerPrefab;

        [Header("Movement")]
        [SerializeField]
        private float _movementSpeed;

        [SerializeField]
        private float _maxX;

        [SerializeField]
        private float _minX;

        [Header("Health")]
        [SerializeField]
        private float _health;

        public GameObject PlayerPrefab => _playerPrefab;
        public float MovementSpeed => _movementSpeed;
        public float Health => _health;
        public float MaxX => _maxX;
        public float MinX => _minX;
    }
}
