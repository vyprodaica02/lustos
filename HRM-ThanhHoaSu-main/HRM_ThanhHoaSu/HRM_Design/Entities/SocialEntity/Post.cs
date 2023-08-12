using HRM_Design.Common;
using HRM_Design.Entities.SocialEntity;
using HRM_Design.Entities.UserEntity;
using HRM_Design.Enums.PostEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Entities.SocialEntity
{
    public class Post : BaseEntity
    {
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int UserCreateId { get; set; }
        public virtual User UserCreate { get; set; }
        public int? GroupId { get; set; }
        public virtual Group? Group { get; set; }
        public int CountReact { get; set; }
        public int CountComment { get; set; }
        public int CountShare { get; set; }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
        public PostStatusEnum PostStatus { get; set; }
        public PostObjectEnum PostObject { get; set; }
        public TypePostEnum TypePost { get; set; }
        public virtual IEnumerable<ReactPost> ReactList { get; set; }
    }
}
