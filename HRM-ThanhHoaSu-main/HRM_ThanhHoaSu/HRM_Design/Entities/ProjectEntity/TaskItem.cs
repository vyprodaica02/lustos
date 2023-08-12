using HRM_Design.Common;
using HRM_Design.Entities.UserEntity;
using HRM_Design.Enums.ProjectEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.ProjectEntity
{
    public class TaskItem : BaseEntity
    {
        public int ProgressCatalogId { get; set; }
        public virtual ProgressCatalog ProgressCatalog { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public int CreateUserId { get; set; }
        public virtual User CreateUser { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime Deadline { get; set; }
    }
}
