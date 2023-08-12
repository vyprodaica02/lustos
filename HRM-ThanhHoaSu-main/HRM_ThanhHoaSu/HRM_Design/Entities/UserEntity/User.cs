using HRM_Design.Common;
using HRM_Design.Entities.ProjectEntity;
using HRM_Design.Entities.Relation;
using HRM_Design.Entities.SocialEntity;
using HRM_Design.Entities.TimeKeeping;
using HRM_Design.Enums.UserEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HRM_Design.Entities.UserEntity
{
    public class User : BaseEntity
    {
        public string? Email { get; set; }
        public string? Code { get; set; }
        public string? UserAvatar { get; set; }
        public string? UserWallImage { get; set; }
        public string? Password { get; set; }
        public string? ContactCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? NickName { get; set; }
        public string? FisrtName { get; set; }
        public string? Lastname { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? Address { get; set; }
        public int? IntroduceUserId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual User? IntroduceUser { get; set; }
        public int? HrId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual User? Hr { get; set; }
        public double? PayLeave { get; set; }
        public double? PaidLeave { get; set; }
        public double? UnPaidLeave { get; set; }
        public UserStatusEnum? UserStatus { get; set; }
        public TypeUserEnum? TypeUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual IEnumerable<User>? IntroduceList { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual IEnumerable<User>? RecruitmentList { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual IEnumerable<UserRole>? UserRoles { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual IEnumerable<FriendRequest>? SendList { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual IEnumerable<FriendRequest>? TakeList { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual IEnumerable<UserFriend>? FriendOf { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual IEnumerable<UserFriend>? FriendList { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual IEnumerable<UserGroup>? UserGroups { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual IEnumerable<Comment>? CommentList { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual IEnumerable<UserDepartment>? UserDepartments { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual IEnumerable<Project>? PmProject { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual IEnumerable<Project>? PoProject { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual IEnumerable<TaskMember>? TaskList { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual IEnumerable<ReactCommentTask>? ReactCommentTaskList { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual IEnumerable<TaskItem>? CreateTaskItemList { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual IEnumerable<Attendance>? AttendanceList { get; set; }

    }
}
