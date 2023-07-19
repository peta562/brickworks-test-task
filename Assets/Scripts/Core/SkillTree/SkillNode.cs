using System.Collections.Generic;

namespace Core.SkillTree {
    public class SkillNode {
        public int Id { get; }
        public string Name { get; }
        public int LearnPrice { get; }
        public List<SkillNode> ChildrenSkills { get; }
        public bool IsLearned { get; private set; }

        public SkillNode(int id, string name, int learnPrice, List<SkillNode> childrenSkills, bool isLearned) {
            Id = id;
            Name = name;
            LearnPrice = learnPrice; 
            ChildrenSkills = childrenSkills;
            IsLearned = isLearned;
        }

        public void Learn() {
            IsLearned = true;
        }

        public void Forget() {
            IsLearned = false;
        }
    }
}