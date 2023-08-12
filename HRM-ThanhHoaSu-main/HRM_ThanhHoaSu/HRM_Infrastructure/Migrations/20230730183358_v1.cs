using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "qa_bonusElses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BonusAmount = table.Column<double>(type: "float", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_bonusElses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "qa_departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMember = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "qa_projectStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_projectStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "qa_roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "qa_users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAvatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserWallImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FisrtName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroduceUserId = table.Column<int>(type: "int", nullable: true),
                    HrId = table.Column<int>(type: "int", nullable: true),
                    PayLeave = table.Column<double>(type: "float", nullable: false),
                    PaidLeave = table.Column<double>(type: "float", nullable: false),
                    UnPaidLeave = table.Column<double>(type: "float", nullable: false),
                    UserStatus = table.Column<int>(type: "int", nullable: false),
                    TypeUser = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_users_qa_users_HrId",
                        column: x => x.HrId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_qa_users_qa_users_IntroduceUserId",
                        column: x => x.IntroduceUserId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "qa_workShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StandardMinute = table.Column<int>(type: "int", nullable: false),
                    OverTimeMinute = table.Column<int>(type: "int", nullable: true),
                    IsAcceptOT = table.Column<bool>(type: "bit", nullable: false),
                    OpenTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    WorkShiftType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_workShifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "qa_friendRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserSendId = table.Column<int>(type: "int", nullable: false),
                    UserTakeId = table.Column<int>(type: "int", nullable: false),
                    SendTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_friendRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_friendRequests_qa_users_UserSendId",
                        column: x => x.UserSendId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_qa_friendRequests_qa_users_UserTakeId",
                        column: x => x.UserTakeId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "qa_groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupAvatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupWallImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreateId = table.Column<int>(type: "int", nullable: false),
                    GroupStatusEnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_groups_qa_users_UserCreateId",
                        column: x => x.UserCreateId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qa_projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoId = table.Column<int>(type: "int", nullable: false),
                    PmId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimateDay = table.Column<int>(type: "int", nullable: false),
                    IsLate = table.Column<bool>(type: "bit", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_projects_qa_projectStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "qa_projectStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_qa_projects_qa_users_PmId",
                        column: x => x.PmId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_qa_projects_qa_users_PoId",
                        column: x => x.PoId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "qa_salaryBills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BillOf = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_salaryBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_salaryBills_qa_users_UserId",
                        column: x => x.UserId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qa_userDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    JoinTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SortNumber = table.Column<int>(type: "int", nullable: false),
                    DepartmentRole = table.Column<int>(type: "int", nullable: false),
                    UserDepartmentStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_userDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_userDepartments_qa_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "qa_departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_qa_userDepartments_qa_users_UserId",
                        column: x => x.UserId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qa_userFriends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FriendId = table.Column<int>(type: "int", nullable: false),
                    AcceptFriendTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_userFriends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_userFriends_qa_users_FriendId",
                        column: x => x.FriendId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_qa_userFriends_qa_users_UserId",
                        column: x => x.UserId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "qa_userRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    AddTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_userRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_userRoles_qa_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "qa_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_qa_userRoles_qa_users_UserId",
                        column: x => x.UserId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qa_contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WorkShiftId = table.Column<int>(type: "int", nullable: false),
                    StandardSalary = table.Column<double>(type: "float", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUpdate = table.Column<bool>(type: "bit", nullable: false),
                    IsWorkShiftDynamic = table.Column<bool>(type: "bit", nullable: false),
                    UserWorkShiftBoardType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_contracts_qa_users_UserId",
                        column: x => x.UserId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_qa_contracts_qa_workShifts_WorkShiftId",
                        column: x => x.WorkShiftId,
                        principalTable: "qa_workShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qa_posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreateId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    CountReact = table.Column<int>(type: "int", nullable: false),
                    CountComment = table.Column<int>(type: "int", nullable: false),
                    CountShare = table.Column<int>(type: "int", nullable: false),
                    PostStatus = table.Column<int>(type: "int", nullable: false),
                    PostObject = table.Column<int>(type: "int", nullable: false),
                    TypePost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_posts_qa_groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "qa_groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_qa_posts_qa_users_UserCreateId",
                        column: x => x.UserCreateId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qa_userGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    JoinTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_userGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_userGroups_qa_groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "qa_groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_qa_userGroups_qa_users_UserId",
                        column: x => x.UserId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "qa_progressBoards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    BoardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_progressBoards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_progressBoards_qa_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "qa_projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_qa_progressBoards_qa_users_CreateUserId",
                        column: x => x.CreateUserId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qa_projectDocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_projectDocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_projectDocs_qa_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "qa_projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qa_userProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    JoinTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_userProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_userProjects_qa_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "qa_projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_qa_userProjects_qa_users_UserId",
                        column: x => x.UserId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qa_salaryBillBonusElses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryBillId = table.Column<int>(type: "int", nullable: false),
                    BonusElseId = table.Column<int>(type: "int", nullable: false),
                    AddTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_salaryBillBonusElses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_salaryBillBonusElses_qa_bonusElses_BonusElseId",
                        column: x => x.BonusElseId,
                        principalTable: "qa_bonusElses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_qa_salaryBillBonusElses_qa_salaryBills_SalaryBillId",
                        column: x => x.SalaryBillId,
                        principalTable: "qa_salaryBills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qa_attendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    WorkShiftId = table.Column<int>(type: "int", nullable: false),
                    TotalWorkMinute = table.Column<int>(type: "int", nullable: false),
                    IsOverTime = table.Column<bool>(type: "bit", nullable: false),
                    EnterTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeAttendance = table.Column<int>(type: "int", nullable: false),
                    AttendanceStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_attendances_qa_contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "qa_contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_qa_attendances_qa_users_UserId",
                        column: x => x.UserId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_qa_attendances_qa_workShifts_WorkShiftId",
                        column: x => x.WorkShiftId,
                        principalTable: "qa_workShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "qa_contractBonuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    BonusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BonusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BonusAmount = table.Column<double>(type: "float", nullable: false),
                    ContractBonusStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_contractBonuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_contractBonuses_qa_contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "qa_contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qa_updateContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    WorkShiftId = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_updateContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_updateContracts_qa_contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "qa_contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_qa_updateContracts_qa_workShifts_WorkShiftId",
                        column: x => x.WorkShiftId,
                        principalTable: "qa_workShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "qa_comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreateId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CountReact = table.Column<int>(type: "int", nullable: false),
                    CountSubComment = table.Column<int>(type: "int", nullable: false),
                    CommentParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_comments_qa_comments_CommentParentId",
                        column: x => x.CommentParentId,
                        principalTable: "qa_comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_qa_comments_qa_posts_PostId",
                        column: x => x.PostId,
                        principalTable: "qa_posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_qa_comments_qa_users_CommentParentId",
                        column: x => x.CommentParentId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "qa_reactPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    ReactEnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_reactPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_reactPosts_qa_posts_PostId",
                        column: x => x.PostId,
                        principalTable: "qa_posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_qa_reactPosts_qa_users_UserId",
                        column: x => x.UserId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qa_progressCatalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgressBoardId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsMemberCanUpdate = table.Column<bool>(type: "bit", nullable: false),
                    SortNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_progressCatalogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_progressCatalogs_qa_progressBoards_ProgressBoardId",
                        column: x => x.ProgressBoardId,
                        principalTable: "qa_progressBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qa_explanations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceId = table.Column<int>(type: "int", nullable: false),
                    ExplanationContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExplanationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExplanationStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_explanations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_explanations_qa_attendances_AttendanceId",
                        column: x => x.AttendanceId,
                        principalTable: "qa_attendances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qa_reactComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    ReactEnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_reactComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_reactComments_qa_comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "qa_comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_qa_reactComments_qa_users_UserId",
                        column: x => x.UserId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qa_reactCommentTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    ReactEnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_reactCommentTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_reactCommentTasks_qa_comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "qa_comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_qa_reactCommentTasks_qa_users_UserId",
                        column: x => x.UserId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "qa_taskItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgressCatalogId = table.Column<int>(type: "int", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_taskItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_taskItems_qa_progressCatalogs_ProgressCatalogId",
                        column: x => x.ProgressCatalogId,
                        principalTable: "qa_progressCatalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_qa_taskItems_qa_users_CreateUserId",
                        column: x => x.CreateUserId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "qa_commentTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskItemId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_commentTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_commentTasks_qa_taskItems_TaskItemId",
                        column: x => x.TaskItemId,
                        principalTable: "qa_taskItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qa_flags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskItemId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_flags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_flags_qa_taskItems_TaskItemId",
                        column: x => x.TaskItemId,
                        principalTable: "qa_taskItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qa_taskFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskItemId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_taskFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_taskFiles_qa_taskItems_TaskItemId",
                        column: x => x.TaskItemId,
                        principalTable: "qa_taskItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qa_taskImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskItemId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_taskImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_taskImages_qa_taskItems_TaskItemId",
                        column: x => x.TaskItemId,
                        principalTable: "qa_taskItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qa_taskMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskItemId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AddTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qa_taskMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qa_taskMember_qa_taskItems_TaskItemId",
                        column: x => x.TaskItemId,
                        principalTable: "qa_taskItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_qa_taskMember_qa_users_UserId",
                        column: x => x.UserId,
                        principalTable: "qa_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_qa_attendances_ContractId",
                table: "qa_attendances",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_attendances_UserId",
                table: "qa_attendances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_attendances_WorkShiftId",
                table: "qa_attendances",
                column: "WorkShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_comments_CommentParentId",
                table: "qa_comments",
                column: "CommentParentId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_comments_PostId",
                table: "qa_comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_commentTasks_TaskItemId",
                table: "qa_commentTasks",
                column: "TaskItemId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_contractBonuses_ContractId",
                table: "qa_contractBonuses",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_contracts_UserId",
                table: "qa_contracts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_contracts_WorkShiftId",
                table: "qa_contracts",
                column: "WorkShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_explanations_AttendanceId",
                table: "qa_explanations",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_flags_TaskItemId",
                table: "qa_flags",
                column: "TaskItemId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_friendRequests_UserSendId",
                table: "qa_friendRequests",
                column: "UserSendId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_friendRequests_UserTakeId",
                table: "qa_friendRequests",
                column: "UserTakeId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_groups_UserCreateId",
                table: "qa_groups",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_posts_GroupId",
                table: "qa_posts",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_posts_UserCreateId",
                table: "qa_posts",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_progressBoards_CreateUserId",
                table: "qa_progressBoards",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_progressBoards_ProjectId",
                table: "qa_progressBoards",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_progressCatalogs_ProgressBoardId",
                table: "qa_progressCatalogs",
                column: "ProgressBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_projectDocs_ProjectId",
                table: "qa_projectDocs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_projects_PmId",
                table: "qa_projects",
                column: "PmId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_projects_PoId",
                table: "qa_projects",
                column: "PoId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_projects_StatusId",
                table: "qa_projects",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_reactComments_CommentId",
                table: "qa_reactComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_reactComments_UserId",
                table: "qa_reactComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_reactCommentTasks_CommentId",
                table: "qa_reactCommentTasks",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_reactCommentTasks_UserId",
                table: "qa_reactCommentTasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_reactPosts_PostId",
                table: "qa_reactPosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_reactPosts_UserId",
                table: "qa_reactPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_salaryBillBonusElses_BonusElseId",
                table: "qa_salaryBillBonusElses",
                column: "BonusElseId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_salaryBillBonusElses_SalaryBillId",
                table: "qa_salaryBillBonusElses",
                column: "SalaryBillId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_salaryBills_UserId",
                table: "qa_salaryBills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_taskFiles_TaskItemId",
                table: "qa_taskFiles",
                column: "TaskItemId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_taskImages_TaskItemId",
                table: "qa_taskImages",
                column: "TaskItemId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_taskItems_CreateUserId",
                table: "qa_taskItems",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_taskItems_ProgressCatalogId",
                table: "qa_taskItems",
                column: "ProgressCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_taskMember_TaskItemId",
                table: "qa_taskMember",
                column: "TaskItemId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_taskMember_UserId",
                table: "qa_taskMember",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_updateContracts_ContractId",
                table: "qa_updateContracts",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_updateContracts_WorkShiftId",
                table: "qa_updateContracts",
                column: "WorkShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_userDepartments_DepartmentId",
                table: "qa_userDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_userDepartments_UserId",
                table: "qa_userDepartments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_userFriends_FriendId",
                table: "qa_userFriends",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_userFriends_UserId",
                table: "qa_userFriends",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_userGroups_GroupId",
                table: "qa_userGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_userGroups_UserId",
                table: "qa_userGroups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_userProjects_ProjectId",
                table: "qa_userProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_userProjects_UserId",
                table: "qa_userProjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_userRoles_RoleId",
                table: "qa_userRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_userRoles_UserId",
                table: "qa_userRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_users_HrId",
                table: "qa_users",
                column: "HrId");

            migrationBuilder.CreateIndex(
                name: "IX_qa_users_IntroduceUserId",
                table: "qa_users",
                column: "IntroduceUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "qa_commentTasks");

            migrationBuilder.DropTable(
                name: "qa_contractBonuses");

            migrationBuilder.DropTable(
                name: "qa_explanations");

            migrationBuilder.DropTable(
                name: "qa_flags");

            migrationBuilder.DropTable(
                name: "qa_friendRequests");

            migrationBuilder.DropTable(
                name: "qa_projectDocs");

            migrationBuilder.DropTable(
                name: "qa_reactComments");

            migrationBuilder.DropTable(
                name: "qa_reactCommentTasks");

            migrationBuilder.DropTable(
                name: "qa_reactPosts");

            migrationBuilder.DropTable(
                name: "qa_salaryBillBonusElses");

            migrationBuilder.DropTable(
                name: "qa_taskFiles");

            migrationBuilder.DropTable(
                name: "qa_taskImages");

            migrationBuilder.DropTable(
                name: "qa_taskMember");

            migrationBuilder.DropTable(
                name: "qa_updateContracts");

            migrationBuilder.DropTable(
                name: "qa_userDepartments");

            migrationBuilder.DropTable(
                name: "qa_userFriends");

            migrationBuilder.DropTable(
                name: "qa_userGroups");

            migrationBuilder.DropTable(
                name: "qa_userProjects");

            migrationBuilder.DropTable(
                name: "qa_userRoles");

            migrationBuilder.DropTable(
                name: "qa_attendances");

            migrationBuilder.DropTable(
                name: "qa_comments");

            migrationBuilder.DropTable(
                name: "qa_bonusElses");

            migrationBuilder.DropTable(
                name: "qa_salaryBills");

            migrationBuilder.DropTable(
                name: "qa_taskItems");

            migrationBuilder.DropTable(
                name: "qa_departments");

            migrationBuilder.DropTable(
                name: "qa_roles");

            migrationBuilder.DropTable(
                name: "qa_contracts");

            migrationBuilder.DropTable(
                name: "qa_posts");

            migrationBuilder.DropTable(
                name: "qa_progressCatalogs");

            migrationBuilder.DropTable(
                name: "qa_workShifts");

            migrationBuilder.DropTable(
                name: "qa_groups");

            migrationBuilder.DropTable(
                name: "qa_progressBoards");

            migrationBuilder.DropTable(
                name: "qa_projects");

            migrationBuilder.DropTable(
                name: "qa_projectStatuses");

            migrationBuilder.DropTable(
                name: "qa_users");
        }
    }
}
