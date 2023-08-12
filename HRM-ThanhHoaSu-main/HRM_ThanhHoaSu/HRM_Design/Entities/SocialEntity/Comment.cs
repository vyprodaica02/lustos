using HRM_Design.Common;
using HRM_Design.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.SocialEntity
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public string? ImagePath { get; set; }
        public int UserCreateId { get; set; }
        public virtual User UserCreate { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int CountReact { get; set; }
        public int CountSubComment { get; set; }
        public int? CommentParentId { get; set; }
        public virtual Comment ParentComment { get; set; }
        public virtual IEnumerable<Comment>? ChildComments { get; set; }

        public virtual IEnumerable<ReactComment> ReactList { get; set; }
    }
}
