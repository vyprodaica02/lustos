using HRM_Design.Common;
using HRM_Design.Enums.ProjectEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.ProjectEntity
{
    public class ProjectDoc : BaseEntity
    {
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime AddTime { get; set; }
        public FileTypeEnum FileType { get; set; }
    }
}
