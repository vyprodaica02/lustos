using HRM_Design.Common;
using HRM_Design.Entities.Relation;
using HRM_Design.Entities.UserEntity;
using HRM_Design.Enums.GroupEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.SocialEntity
{
    public class Group : BaseEntity
    {
        public string GroupName { get; set; }
        public string GroupAvatar { get; set; }
        public string GroupWallImage { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int UserCreateId { get; set; }
        public virtual User UserCreate {get;set; }
        public GroupStatusEnum GroupStatusEnum { get; set; }
        public virtual IEnumerable<Post> Posts { get; set; }
        public virtual IEnumerable<UserGroup> UserGroups { get; set; }
    }
}
