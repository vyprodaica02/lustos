using HRM_Design.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.UserEntity
{
    public class UserFriend : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int FriendId { get; set;}
        public virtual User Friend { get; set; }
        public DateTime AcceptFriendTime { get; set; }

    }
}
