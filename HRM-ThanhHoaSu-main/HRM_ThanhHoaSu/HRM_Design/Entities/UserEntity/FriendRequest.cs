using HRM_Design.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.UserEntity
{
    public class FriendRequest : BaseEntity
    {
        public int UserSendId { get; set; }
        public virtual User UserSend { get; set; }
        public int UserTakeId { get; set; }
        public virtual User UserTake { get; set; }
        public DateTime SendTime { get; set; }
    }
}
