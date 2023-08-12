using HRM_Design.Common;
using HRM_Design.Entities.ProjectEntity;
using HRM_Design.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.Relation
{
    public class UserProject : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set;}
        public DateTime JoinTime { get; set; }

    }
}
