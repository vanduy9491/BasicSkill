using System;
using System.Collections.Generic;

#nullable disable

namespace BasicSkillProject.Models
{
    public partial class SchoolYear
    {
        public SchoolYear()
        {
            UserOfSchoolYears = new HashSet<UserOfSchoolYear>();
        }

        public int Id { get; set; }
        public string SchoolYear1 { get; set; }

        public virtual ICollection<UserOfSchoolYear> UserOfSchoolYears { get; set; }
    }
}
