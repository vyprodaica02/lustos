using HRM_Design.Entities.ProjectEntity;
using HRM_Design.Entities.Relation;
using HRM_Design.Entities.SalaryCalcul;
using HRM_Design.Entities.SocialEntity;
using HRM_Design.Entities.TimeKeeping;
using HRM_Design.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Infrastructure.DataEx
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Integrated Security=true;Initial Catalog=dbSuThanhHoa;MultipleActiveResultSets=True;encrypt=true;trustservercertificate=true");
        }
        #region Project
        public DbSet<Project> qa_projects { get; set; }
        public DbSet<CommentTask> qa_commentTasks { get; set; }
        public DbSet<Flag> qa_flags { get; set; }
        public DbSet<ProgressBoard> qa_progressBoards { get; set; }
        public DbSet<ProgressCatalog> qa_progressCatalogs { get; set; }
        public DbSet<ProjectDoc> qa_projectDocs { get; set; }
        public DbSet<ProjectStatus> qa_projectStatuses { get; set; }
        public DbSet<ReactCommentTask> qa_reactCommentTasks { get; set; }
        public DbSet<TaskFile> qa_taskFiles { get; set; }
        public DbSet<TaskImage> qa_taskImages { get; set; }
        public DbSet<TaskItem> qa_taskItems { get; set; }
        public DbSet<TaskMember> qa_taskMember { get; set; }

        #endregion
        #region Relation
        public DbSet<UserGroup> qa_userGroups { get; set; }
        public DbSet<UserProject> qa_userProjects { get; set; }
        #endregion
        #region User
        public DbSet<Department> qa_departments { get; set; }
        public DbSet<FriendRequest> qa_friendRequests { get; set; }
        public DbSet<Role> qa_roles { get; set; }
        public DbSet<User> qa_users { get; set; }
        public DbSet<UserDepartment> qa_userDepartments { get; set; }
        public DbSet<UserFriend> qa_userFriends { get; set; }
        public DbSet<UserRole> qa_userRoles { get; set; }

        #endregion
        #region Social
        public DbSet<Comment> qa_comments { get; set; }
        public DbSet<Group> qa_groups { get; set; }
        public DbSet<Post> qa_posts { get; set; }
        public DbSet<ReactComment> qa_reactComments { get; set; }
        public DbSet<ReactPost> qa_reactPosts { get; set; }
        #endregion
        #region TimeKeeping
        public DbSet<Attendance> qa_attendances { get; set; }
        public DbSet<Contract> qa_contracts { get; set; }
        public DbSet<ContractBonus> qa_contractBonuses { get; set; }
        public DbSet<Explanation> qa_explanations { get; set; }
        public DbSet<UpdateContract> qa_updateContracts { get; set; }
        public DbSet<WorkShift> qa_workShifts { get; set; }
        #endregion
        #region SalaryCalcul
        public DbSet<BonusElse> qa_bonusElses { get; set; }
        public DbSet<SalaryBill> qa_salaryBills { get; set; }
        public DbSet<SalaryBillBonusElse> qa_salaryBillBonusElses { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendRequest>().HasOne(x => x.UserSend).WithMany(x => x.SendList).HasForeignKey(x => x.UserSendId).OnDelete(DeleteBehavior.Restrict); 
            modelBuilder.Entity<FriendRequest>().HasOne(x => x.UserTake).WithMany(x => x.TakeList).HasForeignKey(x => x.UserTakeId).OnDelete(DeleteBehavior.Restrict); 
            modelBuilder.Entity<UserFriend>().HasOne(x => x.User).WithMany(x => x.FriendList).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserFriend>().HasOne(x => x.Friend).WithMany(x => x.FriendOf).HasForeignKey(x => x.FriendId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserGroup>().HasOne(x => x.User).WithMany(x => x.UserGroups).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Comment>().HasOne(x => x.ParentComment).WithMany(x => x.ChildComments).HasForeignKey(x => x.CommentParentId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Comment>().HasOne(x => x.UserCreate).WithMany(x => x.CommentList).HasForeignKey(x => x.CommentParentId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ReactComment>().HasOne(x => x.Comment).WithMany(x => x.ReactList).HasForeignKey(x => x.CommentId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ReactPost>().HasOne(x => x.Post).WithMany(x => x.ReactList).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Project>().HasOne(x => x.Po).WithMany(x => x.PoProject).HasForeignKey(x => x.PoId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Project>().HasOne(x => x.Pm).WithMany(x => x.PmProject).HasForeignKey(x => x.PmId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TaskMember>().HasOne(x => x.User).WithMany(x => x.TaskList).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ReactCommentTask>().HasOne(x => x.User).WithMany(x => x.ReactCommentTaskList).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasOne(x => x.Hr).WithMany(x => x.RecruitmentList).HasForeignKey(x => x.HrId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasOne(x => x.IntroduceUser).WithMany(x => x.IntroduceList).HasForeignKey(x => x.IntroduceUserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UpdateContract>().HasOne(x => x.WorkShift).WithMany(x => x.UpdateContractList).HasForeignKey(x => x.WorkShiftId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TaskItem>().HasOne(x => x.CreateUser).WithMany(x => x.CreateTaskItemList).HasForeignKey(x => x.CreateUserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Attendance>().HasOne(x => x.User).WithMany(x => x.AttendanceList).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Attendance>().HasOne(x => x.WorkShift).WithMany(x => x.AttendanceList).HasForeignKey(x => x.WorkShiftId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
