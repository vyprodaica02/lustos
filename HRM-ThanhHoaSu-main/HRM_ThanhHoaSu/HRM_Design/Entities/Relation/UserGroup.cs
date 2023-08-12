using HRM_Design.Common;
using HRM_Design.Entities.SocialEntity;
using HRM_Design.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.Relation
{
    public class UserGroup : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public DateTime JoinTime { get; set; }
    }
}
