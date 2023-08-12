using HRM_Design.Common;
using HRM_Design.Enums.UserEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.UserEntity
{
    public class UserDepartment : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public DateTime JoinTime { get; set; }
        public DateTime? LeaveTime { get; set; }
        /// <summary>
        /// Thứ tự các lần gia nhập vào phòng ban
        /// </summary>
        public int SortNumber { get; set; }
        public DepartmentRoleEnum DepartmentRole { get; set; }
        public UserDepartmentStatusEnum UserDepartmentStatus { get; set; }

    }
}
