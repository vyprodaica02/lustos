using HRM_Design.Common;
using HRM_Design.Entities.SocialEntity;
using HRM_Design.Entities.UserEntity;
using HRM_Design.Enums.ReactEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.ProjectEntity
{
    public class ReactCommentTask : BaseEntity
    {
        public DateTime CreateTime { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        public ReactEnum ReactEnum { get; set; }
    }
}
