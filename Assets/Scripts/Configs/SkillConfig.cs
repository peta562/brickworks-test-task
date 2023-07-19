using System.Collections.Generic;
using UnityEngine;

namespace Configs {
    [CreateAssetMenu(fileName = nameof(SkillConfig), menuName = "Configs/" + nameof(SkillConfig), order = 0)]
    public class SkillConfig : ScriptableObject {
        public int Id;
        public string Name;
        public int RequiredPoints;
        public List<SkillConfig> ChildrenSkillsConfigs;
        public bool IsRootSkill;
    }
}