using HRM_Design.Common;
using HRM_Design.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.SalaryCalcul
{
    public class SalaryBill : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        /// <summary>
        /// Bảng lương của tháng năm nào.
        /// </summary>
        public DateTime BillOf { get; set; }
        public double Salary { get; set; }

    }
}
