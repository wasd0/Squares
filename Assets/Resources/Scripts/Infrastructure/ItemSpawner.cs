using System.Collections;
using System.Collections.Generic;
using Resources.Scripts.Applications;
using Resources.Scripts.MonoBehaviours;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Resources.Scripts.Infrastructure
{
    public class ItemSpawner
    {
        private readonly SceneData _sceneData;
        private readonly ItemsApplicationFactory _itemsApplicationFactory;
        private readonly List<ItemApplication> _itemApplications;
        private const int PREFABS_COUNT = 2;

        public ItemSpawner(SceneData sceneData)
        {
            _sceneData = sceneData;
            _itemApplications = new List<ItemApplication>();
            _itemsApplicationFactory =
                new ItemsApplicationFactory(_sceneData.ItemEndPoint.position, _sceneData.ItemsFallMultiplier);
        }

        public IEnumerator StartSpawn()
        {
            int counter = 0;
            var spawnPoints = _sceneData.ItemSpawnPoints;
            while (counter < _sceneData.ItemsCount)
            {
                int pointIndex = Random.Range(1, spawnPoints.Length);
                Vector2 spawn = spawnPoints[pointIndex].position;
                counter++;
                SpawnRandom(spawn);
                yield return new WaitForSeconds(_sceneData.SpawnDelaySecs);
            }
        }

        public void Update()
        {
            foreach (var item in _itemApplications)
            {
                item.Update();
            }
        }

        public void LateUpdate()
        {
            foreach (var item in _itemApplications)
            {
                item.LateUpdate();
            }
        }

        private void SpawnRandom(Vector2 spawn)
        {
            int prefabNumber = Random.Range(1, PREFABS_COUNT + 1);
            var prefab = prefabNumber == 1 ? _sceneData.BonusPrefab : _sceneData.ObstaclePrefab;
            var item = Object.Instantiate(prefab, spawn, Quaternion.identity, null);
            _itemApplications.Add(_itemsApplicationFactory.Create(item, spawn));
        }
    }
}
