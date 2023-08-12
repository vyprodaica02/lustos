using HRM_Design.Common;
using HRM_Design.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HRM_Design.Entities.ProjectEntity
{
    public class Project : BaseEntity
    {
        public string ProjectName { get; set; }
        public int? PoId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual User? Po { get; set; }
        public int? PmId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual User? Pm { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DateTime { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]

        public int? EstimateDay { get; set; }
        public bool? IsLate { get; set; }
        public int? StatusId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual ProjectStatus? Status { get; set; }
    }
}
