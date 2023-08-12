using HRM_Design.Entities.ProjectEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.IService.IProjectService
{
    public interface IProjectService
    {
        public Task<IQueryable<Project>> GetAll();
    }
}
