using HRM_Design.Common;
using HRM_Design.Entities.UserEntity;
using HRM_Design.Enums.ReactEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.SocialEntity
{
    public class ReactPost : BaseEntity
    {
        public DateTime CreateTime { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public ReactEnum ReactEnum { get; set; }
    }
}
