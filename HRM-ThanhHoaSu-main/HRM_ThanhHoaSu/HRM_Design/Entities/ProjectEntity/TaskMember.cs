using HRM_Design.Common;
using HRM_Design.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.ProjectEntity
{
    public class TaskMember : BaseEntity
    {
        public int TaskItemId { get; set; }
        public virtual TaskItem TaskItem { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime AddTime { get; set; }
    }
}
