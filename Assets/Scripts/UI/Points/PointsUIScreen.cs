using Core;
using UnityEngine;

namespace UI.Points {
    public class PointsUIScreen : MonoBehaviour {
        [SerializeField] PointsView PointsView;
        PointsController _pointsController;

        public void Init(PointsController pointsController) {
            _pointsController = pointsController;
            
            PointsView.Init(OnEarnButtonClicked);
            UpdatePointsView();
        }
        
        public void DeInit() {
            PointsView.DeInit();
        }

        public void UpdatePointsView() {
            PointsView.UpdatePointsText(_pointsController.Points);
        }

        void OnEarnButtonClicked() {
            _pointsController.IncreasePoints();
        }
    }
}