using HRM_Design.Common;
using HRM_Design.Entities.ProjectEntity;
using HRM_Design.IService.IProjectService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Service.ProjectService
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _repository;

        public ProjectService(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public async Task<IQueryable<Project>> GetAll()
        {
            return  _repository.TableUntracked;
        }
    }
}
