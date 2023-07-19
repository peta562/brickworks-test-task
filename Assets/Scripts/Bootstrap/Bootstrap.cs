using Configs;
using Core;
using UI.Points;
using UI.Skills;
using UnityEngine;

namespace Bootstrap {
    public class Bootstrap : MonoBehaviour {
        [SerializeField] SkillConfig RootSkillConfig;
        [SerializeField] SkillsUIScreen SkillsUIScreen;
        [SerializeField] PointsUIScreen PointsUIScreen;

        SkillsController _skillsController;
        PointsController _pointsController;

        void Awake() {
            var skillTreeCreator = new SkillTreeFactory(RootSkillConfig);
            
            _pointsController = new PointsController(PointsUIScreen);
            _skillsController = new SkillsController(skillTreeCreator, SkillsUIScreen, _pointsController);
        }

        void Start() {
            _pointsController.Init();
            _skillsController.Init();
        }

        void OnDestroy() {
            _pointsController.DeInit();
            _skillsController.DeInit();
        }
    }
}