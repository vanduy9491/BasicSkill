using System;
using System.Collections.Generic;

#nullable disable

namespace BasicSkillProject.Models
{
    public partial class AbilityFactor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Tags { get; set; }
        public int? SkillId { get; set; }

        public virtual Skill Skill { get; set; }
    }
}
