using System.Collections.Generic;
using Configs;
using Core.SkillTree;

namespace Core {
    public class SkillTreeFactory {
        readonly SkillConfig _skillRootConfig;

        public SkillTreeFactory(SkillConfig skillRootConfig) {
            _skillRootConfig = skillRootConfig;
        }

        readonly Dictionary<int, SkillNode> _createdSkills = new();
        
        public SkillTree.SkillTree CreateSkillTree() {
            var skillRoot = CreateSkill(_skillRootConfig);
            
            var skillTree = new SkillTree.SkillTree(skillRoot, _createdSkills);
            return skillTree;
        }

        SkillNode CreateSkill(SkillConfig skillConfig) {
            var resultChildren = new List<SkillNode>();
            
            foreach (var childrenSkillConfig in skillConfig.ChildrenSkillsConfigs) {
                var createdSkill = GetCreatedSkillWithId(childrenSkillConfig.Id) ?? CreateSkill(childrenSkillConfig);
                resultChildren.Add(createdSkill);
            }

            var skill = new SkillNode(skillConfig.Id, skillConfig.Name, skillConfig.RequiredPoints, resultChildren,
                skillConfig.IsRootSkill);
            _createdSkills.Add(skill.Id, skill);
            
            return skill;
        }

        SkillNode GetCreatedSkillWithId(int id) {
            return _createdSkills.TryGetValue(id, out var skill) ? skill : null;
        }
    }
}