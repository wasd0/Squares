using UnityEngine;

namespace Resources.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player", menuName = "Player Data")]
    public class PlayerStaticData : ScriptableObject
    {
        [Header("Prefab")]
        [SerializeField]
        private GameObject _playerPrefab;

        [Header("Movement")]
        [SerializeField]
        private float _movementSpeed;

        public GameObject PlayerPrefab => _playerPrefab; 
        public float MovementSpeed => _movementSpeed;
    }
}
