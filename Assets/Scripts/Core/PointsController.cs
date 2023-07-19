using UI.Points;

namespace Core {
    public class PointsController {
        readonly PointsUIScreen _pointsUIScreen;
        public int Points { get; private set; }

        public PointsController(PointsUIScreen pointsUIScreen) {
            _pointsUIScreen = pointsUIScreen;
        }

        public void Init() {
            _pointsUIScreen.Init(this);
        }

        public void DeInit() {
            _pointsUIScreen.DeInit();
        }

        public void IncreasePoints() {
            Points += 1;
            _pointsUIScreen.UpdatePointsView();
        }

        public void AddPoints(int points) {
            Points += points;
            _pointsUIScreen.UpdatePointsView();
        }

        public void RemovePoints(int points) {
            Points -= points;
            _pointsUIScreen.UpdatePointsView();
        }
    }
}