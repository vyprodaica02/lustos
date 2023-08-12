using HRM_Design.Common;
using HRM_Design.Entities.UserEntity;
using HRM_Design.Enums.TimeKeepingEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.TimeKeeping
{
    /// <summary>
    /// Hợp đồng với nhân viên
    /// </summary>
    public class Contract : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int WorkShiftId { get; set; }
        public virtual WorkShift WorkShift { get; set; }
        public double StandardSalary { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime CloseTime { get; set; }
        public bool IsUpdate { get; set; }
        /// <summary>
        /// Trường này sẽ xác nhận ca làm việc của nhân viên có linh động trong thời gian hay không 
        /// (ví dụ tuần sáng 6h-14h chiều 14h-22h đêm 22h-6h hôm sau vì tính lương tối sẽ khác sáng và chiều)
        /// </summary>
        public bool IsWorkShiftDynamic { get; set; }
        public UserWorkShiftBoardTypeEnum UserWorkShiftBoardType { get; set; }
    }
}
