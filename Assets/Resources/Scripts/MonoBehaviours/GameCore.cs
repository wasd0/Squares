using Resources.Scripts.Models;
using Resources.Scripts.Presenters;
using Resources.Scripts.Views;
using UnityEngine;

namespace Resources.Scripts.MonoBehaviours
{
    public class GameCore : MonoBehaviour
    {
        [SerializeField]
        private PointsView _pointsView;

        private PointsPresenter _pointsPresenter;
        private PointsModel _pointsModel;
        
        private void Start()
        {
            _pointsModel = new PointsModel();
            _pointsPresenter = new PointsPresenter(_pointsModel, _pointsView);
        }

        private void Update()
        {
            _pointsPresenter.Update();
        }

        private void LateUpdate()
        {
            _pointsPresenter.LateUpdate();
        }
    }
}
