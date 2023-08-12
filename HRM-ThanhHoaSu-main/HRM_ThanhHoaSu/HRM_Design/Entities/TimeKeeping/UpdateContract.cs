using HRM_Design.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.TimeKeeping
{
    public class UpdateContract : BaseEntity
    {
        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }
        public int WorkShiftId { get; set; }
        public virtual WorkShift WorkShift { get; set; } 
        public DateTime UpdateTime { get; set; }
        public int SortNumber { get; set; }

    }
}
