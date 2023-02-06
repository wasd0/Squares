using UnityEngine;

namespace Resources.Scripts.MonoBehaviours
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField]
        private Transform _playerSpawn;

        [SerializeField]
        private Transform _itemSpawn;

        [SerializeField]
        private Transform _itemEndPoint; 
        
        [SerializeField]
        [Range(0, 1)]
        private float _itemsFallMultiplier;

        public Transform PlayerSpawn => _playerSpawn;
        public Transform ItemSpawn => _itemSpawn;

        public Transform ItemEndPoint => _itemEndPoint;

        public float ItemsFloatMultiplier => _itemsFallMultiplier;
    }
}
