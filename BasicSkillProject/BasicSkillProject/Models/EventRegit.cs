using System;
using System.Collections.Generic;

#nullable disable

namespace BasicSkillProject.Models
{
    public partial class EventRegit
    {
        public EventRegit()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public int EventId { get; set; }
        public string UserId { get; set; }
        public string SchoolYear { get; set; }
        public string SchoolActivitie { get; set; }
        public string OwnAction { get; set; }
        public string PowerExerted { get; set; }
        public string DevelopedCapacity { get; set; }
        public string WhatWasThought { get; set; }
        public int? CommentId { get; set; }
        public int? Status { get; set; }

        public virtual Event Event { get; set; }
        public virtual AspNetUser User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
