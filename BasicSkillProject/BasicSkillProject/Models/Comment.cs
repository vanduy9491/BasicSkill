using System;
using System.Collections.Generic;

#nullable disable

namespace BasicSkillProject.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public int EnventRegitsId { get; set; }
        public DateTime? Timestamp { get; set; }

        public virtual EventRegit EnventRegits { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
