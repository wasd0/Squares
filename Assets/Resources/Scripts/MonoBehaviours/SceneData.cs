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
        private Transform _itemSpawn;

        [SerializeField]
        private Transform _itemEndPoint;

        [SerializeField]
        private GameObject _itemPrefab;

        [SerializeField]
        private GameObject _obstaclePrefab;

        [Header("Text")]
        [SerializeField]
        private TMP_Text _healthText;

        [SerializeField]
        private TMP_Text _scoreText;

        public Transform PlayerSpawn => _playerSpawn;
        public Transform ItemSpawn => _itemSpawn;
        public Transform ItemEndPoint => _itemEndPoint;
        public float ItemsFallMultiplier => _itemsFallMultiplier;
        public TMP_Text HealthText => _healthText;
        public TMP_Text ScoreText => _scoreText;
        public GameObject ItemPrefab => _itemPrefab;
        public GameObject ObstaclePrefab => _obstaclePrefab;
    }
}
