using System;
using System.Collections.Generic;

#nullable disable

namespace BasicSkillProject.Models
{
    public partial class UserOfSchoolYear
    {
        public string UserId { get; set; }
        public int SchoolYearId { get; set; }

        public virtual SchoolYear SchoolYear { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
