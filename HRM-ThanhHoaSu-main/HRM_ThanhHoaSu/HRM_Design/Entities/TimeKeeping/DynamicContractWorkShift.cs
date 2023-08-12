using HRM_Design.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.TimeKeeping
{
    /// <summary>
    /// Bảng liệt kê các ca làm việc mà trong hợp đồng lao động yêu cầu người lao động làm việc
    /// Nhưng chú ý 1 ngày người lao động chỉ được làm việc 1 ca trong số các ca liệt kê của hợp đồng
    /// ví dụ hợp đồng có 3 ca Sáng Chiều Tối thì người lao động chỉ được làm 1 trong 3 ca đó thôi.
    /// </summary>
    public class DynamicContractWorkShift : BaseEntity
    {
        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }  
        public int WorkShiftId { get; set; }
        public virtual WorkShift WorkShift { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
