using HRM_Design.Entities.UserEntity;
using HRM_Design.Enums.UserEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.CreateDTO
{
    internal class UserDTO 
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public string UserAvatar { get; set; }
        public string UserWallImage { get; set; }
        public string Password { get; set; }
        public string ContactCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? NickName { get; set; }
        public string FisrtName { get; set; }
        public string Lastname { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? Address { get; set; }
        public int? IntroduceUserId { get; set; }
        //public virtual User? IntroduceUser { get; set; }
        public int? HrId { get; set; }
        //public virtual User? Hr { get; set; }
        public double PayLeave { get; set; }
        public double PaidLeave { get; set; }
        public double UnPaidLeave { get; set; }
        public UserStatusEnum UserStatus { get; set; }
        public TypeUserEnum TypeUser { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
