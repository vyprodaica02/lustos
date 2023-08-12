using HRM_Design.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.ProjectEntity
{
    public class CommentTask : BaseEntity
    {
        public int TaskItemId { get; set; }
        public virtual TaskItem TaskItem { get; set; }
        public string? Content { get; set; }
        public string? ImagePath { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set;}
    }
}
