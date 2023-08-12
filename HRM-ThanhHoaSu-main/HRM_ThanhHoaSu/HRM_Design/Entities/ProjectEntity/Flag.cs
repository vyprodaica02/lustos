using HRM_Design.Common;
using HRM_Design.Enums.ProjectEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.ProjectEntity
{
    /// <summary>
    /// 1 Task có thể gắn nhiều cờ giống Trello
    /// </summary>
    public class Flag : BaseEntity
    {
        public int TaskItemId { get; set; }
        public virtual TaskItem TaskItem { get; set; }
        public string Name { get; set; }
        public string ColorCode { get; set; }
        public DateTime CreateTime { get; set; }
        public FlagStatusEnum Status { get; set; }
    }
}
