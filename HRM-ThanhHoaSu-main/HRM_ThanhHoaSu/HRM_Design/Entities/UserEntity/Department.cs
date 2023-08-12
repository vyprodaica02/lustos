using HRM_Design.Common;
using HRM_Design.Enums.UserEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.UserEntity
{
    public class Department : BaseEntity
    {
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set;}
        public string DepartmentDescription { get; set; }
        //public int LeaderId { get; set; }
        //public virtual User Leader { get; set; }
        //public int? ViceLeaderId { get; set; }
        //public virtual User? ViceLeader { get; set; }
        public int TotalMember { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public DepartmentStatusEnum DepartmentStatus { get; set; }
        public virtual IEnumerable<UserDepartment> UserDepartments { get; set; }
    }
}
