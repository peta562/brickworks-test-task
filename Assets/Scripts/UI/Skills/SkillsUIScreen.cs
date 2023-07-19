using System.Collections.Generic;
using Core;
using Core.SkillTree;
using UnityEngine;

namespace UI.Skills {
    public class SkillsUIScreen : MonoBehaviour {
        [SerializeField] List<SkillView> SkillViews;
        [SerializeField] SkillInteractivePanel SkillInteractivePanel;

        SkillsController _skillsController;

        int _selectedViewId = -1;

        public void Init( SkillsController skillsController) {
            _skillsController = skillsController;

            foreach (var skillView in SkillViews) {
                var skillNode = _skillsController.GetSkillById(skillView.Id);
                skillView.Init(skillNode.Name, skillNode.IsLearned, OnSkillViewSelected);
            }

            SkillInteractivePanel.Init(OnLearnButtonClick, OnForgetButtonClick, OnForgetAllButtonClick);
        }

        public void DeInit() {
            foreach (var skillView in SkillViews) {
                skillView.DeInit();
            }

            SkillInteractivePanel.DeInit();
        }

        public void UpdateSkillView(SkillNode skill) {
            foreach (var skillView in SkillViews) {
                if ( skillView.Id == skill.Id ) {
                    skillView.ChangeLearned(skill.IsLearned, skill.Id != _selectedViewId);
                    UpdateSkillInteractivePanel(skill);
                }
            }
        }

        void OnSkillViewSelected(int id) {
            _selectedViewId = id;
            foreach (var skillView in SkillViews) {
                skillView.ChangeSelect(skillView.Id == _selectedViewId);
            }

            var skill = _skillsController.GetSkillById(_selectedViewId);
            UpdateSkillInteractivePanel(skill);
        }

        void UpdateSkillInteractivePanel(SkillNode skill) {
            var canLearn = _skillsController.CanLearnSkill(skill.Id);
            var canForget = _skillsController.CanForgetSkill(skill.Id);

            SkillInteractivePanel.Setup(canLearn, canForget, skill.LearnPrice);
        }

        void OnLearnButtonClick() {
            _skillsController.LearnSkill(_selectedViewId);
        }

        void OnForgetButtonClick() {
            _skillsController.ForgetSkill(_selectedViewId);
        }

        void OnForgetAllButtonClick() {
            _skillsController.ForgetAllSkills();
        }
    }
}