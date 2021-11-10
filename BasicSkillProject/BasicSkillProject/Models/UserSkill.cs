using System;
using System.Collections.Generic;

#nullable disable

namespace BasicSkillProject.Models
{
    public partial class UserSkill
    {
        public string UserId { get; set; }
        public int SkillId { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
