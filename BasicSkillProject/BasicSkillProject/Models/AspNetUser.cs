using System;
using System.Collections.Generic;

#nullable disable

namespace BasicSkillProject.Models
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserRoles = new HashSet<AspNetUserRole>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            Comments = new HashSet<Comment>();
            EventRegits = new HashSet<EventRegit>();
            UserOfSchoolYears = new HashSet<UserOfSchoolYear>();
            UserSkills = new HashSet<UserSkill>();
        }

        public string Id { get; set; }
        public string Password { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string ParentId { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<EventRegit> EventRegits { get; set; }
        public virtual ICollection<UserOfSchoolYear> UserOfSchoolYears { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
