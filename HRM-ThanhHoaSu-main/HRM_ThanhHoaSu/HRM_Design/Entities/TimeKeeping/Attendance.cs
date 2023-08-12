using HRM_Design.Common;
using HRM_Design.Entities.UserEntity;
using HRM_Design.Enums.TimeKeepingEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HRM_Design.Entities.TimeKeeping
{
    /// <summary>
    /// Điểm danh
    /// </summary>
    public class Attendance : BaseEntity
    {
        public int? UserId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual User? User { get; set; }
        /// <summary>
        /// Chấm công này thuộc hợp đồng nào.
        /// </summary>
        public int? ContractId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual Contract? Contract { get; set; }
        public int? WorkShiftId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual WorkShift? WorkShift { get; set; }
        /// <summary>
        /// Tổng số phút làm việc thực sự
        /// </summary>
        public int? TotalWorkMinute { get; set; }
        /// <summary>
        /// Ca làm việc này có OT không nếu có thì TotalWorkMinute phải tính số phút vượt còn không thì vượt sẽ không tính OT
        /// </summary>
        public bool? IsOverTime { get; set; }
        /// <summary>
        /// Giờ vào
        /// </summary>
        public DateTime? EnterTime { get; set; }
        /// <summary>
        /// Giờ ra
        /// </summary>
        public DateTime? OutTime { get; set; }
        public TypeAttendanceEnum? TypeAttendance { get; set; }
        public AttendanceStatusEnum? AttendanceStatus { get; set; }
    }
}
