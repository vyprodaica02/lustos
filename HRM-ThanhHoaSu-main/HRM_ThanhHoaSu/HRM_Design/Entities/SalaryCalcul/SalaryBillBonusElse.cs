using HRM_Design.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.SalaryCalcul
{
    public class SalaryBillBonusElse : BaseEntity
    {
        public int SalaryBillId { get; set; }
        public virtual SalaryBill SalaryBill { get; set; }
        public int BonusElseId { get; set; }
        public virtual BonusElse BonusElse { get; set; }
        public DateTime AddTime { get; set; }
    }
}
