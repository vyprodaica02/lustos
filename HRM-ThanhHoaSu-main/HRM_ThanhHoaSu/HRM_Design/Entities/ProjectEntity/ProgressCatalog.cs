using HRM_Design.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.ProjectEntity
{
    public class ProgressCatalog : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProgressBoardId { get; set; }
        public virtual ProgressBoard ProgressBoard { get; set; }
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Cho phép thành viên sửa TaskItem ko
        /// </summary>
        public bool IsMemberCanUpdate { get; set; }
        public int SortNumber { get; set; }
    }
}
