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
    /// Phụ cấp trong hợp đồng lao động (Với thưởng dự án sẽ do Finance Team cộng riêng không được phép tạo ở đây bảng này chỉ khai 
    /// báo các phụ cấp như đi lại, ăn trưa, tiền nạp điện thoại,.... Nói chung các phụ cấp ở đây sẽ được cộng thẳng vào bảng lương
    /// cho nhân viên)
    /// </summary>
    public class ContractBonus : BaseEntity
    {
        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }
        public string BonusName { get; set; }
        public string BonusDescription { get; set; }
        public double BonusAmount { get; set; }
        public ContractBonusStatusEnum ContractBonusStatus { get; set; }
    }
}
