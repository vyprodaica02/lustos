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
    /// <summary>
    /// Do tính chất 1 dự án có thể xảy ra nhiều loại vấn đề trong quá trình thực hiện trạng thái sẽ có thể đưa ra làm đánh giá nên tạo bảng quản lý
    /// </summary>
    public class ProjectStatus : BaseEntity
    {
        public string StatusCode { get; set; }
        public string StatusName { get; set; }
        public ProjectStatusEnum Status { get; set; }
        public virtual IEnumerable<Project> ProjectList { get; set; }
    }
}
