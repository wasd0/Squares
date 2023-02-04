using UnityEngine;

namespace Resources.Scripts.MonoBehaviours
{
    public class PointsProvider : MonoBehaviour
    {
        [SerializeField]
        private int _points;

        public int Points => _points;
    }
}