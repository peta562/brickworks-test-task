using System.Collections.Generic;
using System.Linq;

namespace Core.SkillTree {
    public class SkillTree {
        readonly SkillNode _rootSkill;
        readonly Dictionary<int, SkillNode> _allSkills;

        public SkillTree(SkillNode rootSkill, Dictionary<int, SkillNode> allSkills) {
            _rootSkill = rootSkill;
            _allSkills = allSkills;
        }

        public SkillNode GetSkillById(int id) {
            return _allSkills[id];
        }

        public List<SkillNode> GetAllNotRootSkills() {
            return _allSkills.Where(kvp => kvp.Key != _rootSkill.Id)
                .Select(kvp => kvp.Value)
                .ToList();
        }

        public bool CanLearnSkill(int id) {
            if ( id == _rootSkill.Id ) {
                return false;
            }

            return CanLearnSkill(_rootSkill, id);
        }

        public bool CanForgetSkill(int id) {
            if ( id == _rootSkill.Id ) {
                return false;
            }

            return CanForgetSkill(_rootSkill, id);
        }

        bool CanLearnSkill(SkillNode skill, int id) {
            if ( skill.Id == id ) {
                return !skill.IsLearned;
            }

            if ( !skill.IsLearned ) {
                return false;
            }

            foreach (var childrenSkill in skill.ChildrenSkills) {
                if ( CanLearnSkill(childrenSkill, id) ) {
                    return true;
                }
            }

            return false;
        }

        bool CanForgetSkill(SkillNode skill, int id) {
            if ( skill.Id == id ) {
                foreach (var childrenSkill in skill.ChildrenSkills) {
                    if ( childrenSkill.IsLearned ) {
                        return false;
                    }
                }

                return skill.IsLearned;
            }

            if ( !skill.IsLearned ) {
                return false;
            }

            foreach (var childrenSkill in skill.ChildrenSkills) {
                if ( CanForgetSkill(childrenSkill, id) ) {
                    return true;
                }
            }

            return false;
        }
    }
}