using TMPro;
using UnityEngine;

namespace Resources.Scripts.MonoBehaviours
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField]
        [Range(0, 1)]
        private float _itemsFallMultiplier;

        [Header("Player")]
        [SerializeField]
        private Transform _playerSpawn;

        [Header("Item")]
        [SerializeField]
        private Transform _itemEndPoint;

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
        private int _itemsCount;

        [SerializeField]
        [Range(0.5f, 10)]
        private float _spawnDelaySecs;

        [SerializeField]
        private float _respawnDelaySecs;

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
        public float RespawnDelaySecs => _respawnDelaySecs;
        public Transform[] ItemSpawnPoints => _itemSpawnPoints;
    }
}
