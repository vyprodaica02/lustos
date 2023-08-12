using HRM_Design.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.SalaryCalcul
{
    /// <summary>
    /// Thưởng đột xuất (ví dụ: thưởng tết, trung thu,...)
    /// </summary>
    public class BonusElse : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double BonusAmount { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
