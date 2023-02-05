using UnityEngine;

namespace Resources.Scripts.MonoBehaviours
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField]
        private Transform _playerSpawn;

        public Transform PlayerSpawn => _playerSpawn;
    }
}
