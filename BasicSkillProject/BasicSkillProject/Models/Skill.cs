using System;
using System.Collections.Generic;

#nullable disable

namespace BasicSkillProject.Models
{
    public partial class Skill
    {
        public Skill()
        {
            AbilityFactors = new HashSet<AbilityFactor>();
            UserSkills = new HashSet<UserSkill>();
        }

        public int Id { get; set; }
        public string SkillName { get; set; }

        public virtual ICollection<AbilityFactor> AbilityFactors { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
