using HRM_Design.Common;
using HRM_Design.Enums.TimeKeepingEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.TimeKeeping
{
    /// <summary>
    /// Giải trình
    /// </summary>
    public class Explanation : BaseEntity
    {
        public int AttendanceId { get; set; }
        public virtual Attendance Attendance { get; set; }
        public string ExplanationContent { get; set; }
        public DateTime ExplanationTime { get; set; }
        public ExplanationStatusEnum ExplanationStatus { get; set; }
    }
}
