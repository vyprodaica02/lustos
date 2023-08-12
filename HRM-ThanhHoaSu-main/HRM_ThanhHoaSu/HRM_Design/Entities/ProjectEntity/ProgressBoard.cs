using HRM_Design.Common;
using HRM_Design.Entities.UserEntity;
using HRM_Design.Enums.ProjectEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.ProjectEntity
{
    public class ProgressBoard : BaseEntity
    {
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public string BoardName { get; set; }
        public int CreateUserId { get; set; }
        public virtual User CreateUser { get; set; }
        public DateTime CreateTime { get; set; }
        public ProjectBoardEnum Status { get; set; }
    }
}
