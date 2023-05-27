using TMPro;
using UnityEngine;

namespace Scripts.MonoBehaviours
{
    public class SceneData : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField]
        private Transform _playerSpawn;

        [Header("Item")]
        [SerializeField]
        private Transform _itemEndPoint;

        [SerializeField]
        [Range(0, 1)]
        private float _itemsFallMultiplier;

        [SerializeField]
        private GameObject _bonusPrefab;

        [SerializeField]
        private GameObject _obstaclePrefab;

        [Header("Text")]
        [SerializeField]
        private TMP_Text _healthText;

        [SerializeField]
        private TMP_Text _scoreText;

        [Header("Spawner")]
        [SerializeField]
        [Range(10, 100)]
        private int _itemsCount;
        
        [SerializeField]
        [Range(.1f, 10)]
        private float _spawnDelaySecs;

        [SerializeField]
        [Range(1f, 3)]
        private float _respawnDelaySec;

        [SerializeField]
        private Transform[] _itemSpawnPoints;


        public Transform PlayerSpawn => _playerSpawn;
        public Transform ItemEndPoint => _itemEndPoint;
        public float ItemsFallMultiplier => _itemsFallMultiplier;
        public TMP_Text HealthText => _healthText;
        public TMP_Text ScoreText => _scoreText;
        public GameObject BonusPrefab => _bonusPrefab;
        public GameObject ObstaclePrefab => _obstaclePrefab;
        public int ItemsCount => _itemsCount;
        public float SpawnDelaySecs => _spawnDelaySecs;
        public Transform[] ItemSpawnPoints => _itemSpawnPoints;
        public float RespawnDelaySec => _respawnDelaySec;
    }
}
