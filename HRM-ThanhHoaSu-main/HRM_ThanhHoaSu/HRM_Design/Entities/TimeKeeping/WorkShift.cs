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
    /// Ca làm việc
    /// </summary>
    public class WorkShift : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Số phút làm tiêu chuẩn của ca
        /// </summary>
        public int StandardMinute { get; set; }
        /// <summary>
        /// Số phút tối đa được phét OT
        /// </summary>
        public int? OverTimeMinute { get; set; }
        /// <summary>
        /// Ca này có được phép OT hay không
        /// </summary>
        public bool IsAcceptOT { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public WorkShiftStatusEnum Status { get; set; }
        public WorkShiftTypeEnum WorkShiftType { get; set; }
        public virtual IEnumerable<UpdateContract> UpdateContractList { get; set; }
        public virtual IEnumerable<Attendance> AttendanceList { get; set; }
    }
}
