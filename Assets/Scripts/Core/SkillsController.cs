using Core.SkillTree;
using UI.Skills;

namespace Core {
    public class SkillsController {
        readonly SkillTreeFactory _skillTreeFactory;
        readonly SkillsUIScreen _skillsUIScreen;
        readonly PointsController _pointsController;

        SkillTree.SkillTree _skillTree;

        public SkillsController(SkillTreeFactory skillTreeFactory, SkillsUIScreen skillsUIScreen,
            PointsController pointsController) {
            _skillTreeFactory = skillTreeFactory;
            _skillsUIScreen = skillsUIScreen;
            _pointsController = pointsController;
        }

        public void Init() {
            _skillTree = _skillTreeFactory.CreateSkillTree();
            _skillsUIScreen.Init(this);
        }

        public void DeInit() {
            _skillsUIScreen.DeInit();
        }

        public SkillNode GetSkillById(int id) {
            return _skillTree.GetSkillById(id);
        }

        public bool CanLearnSkill(int id) {
            if ( !_skillTree.CanLearnSkill(id) ) {
                return false;
            }

            var skill = _skillTree.GetSkillById(id);
            return _pointsController.Points >= skill.LearnPrice;
        }

        public bool CanForgetSkill(int id) {
            return _skillTree.CanForgetSkill(id);
        }

        public void LearnSkill(int skillId) {
            var skill = _skillTree.GetSkillById(skillId);

            _pointsController.RemovePoints(skill.LearnPrice);
            skill.Learn();
            _skillsUIScreen.UpdateSkillView(skill);
        }

        public void ForgetSkill(int skillId) {
            var skill = _skillTree.GetSkillById(skillId);

            _pointsController.AddPoints(skill.LearnPrice);
            skill.Forget();
            _skillsUIScreen.UpdateSkillView(skill);
        }

        public void ForgetAllSkills() {
            var allSkills = _skillTree.GetAllNotRootSkills();

            foreach (var skill in allSkills) {
                if ( !skill.IsLearned ) {
                    continue;
                }

                _pointsController.AddPoints(skill.LearnPrice);
                skill.Forget();
                _skillsUIScreen.UpdateSkillView(skill);
            }
        }
    }
}