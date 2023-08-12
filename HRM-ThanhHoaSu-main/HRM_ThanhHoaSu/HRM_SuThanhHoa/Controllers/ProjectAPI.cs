using HRM_Design.Entities.ProjectEntity;
using HRM_Design.IService.IProjectService;
using HRM_Design.Service.ProjectService;
using HRM_Infrastructure.DataEx;
using Microsoft.AspNetCore.Mvc;
using HRM_Design.Common;
using HRM_Design.Entities.UserEntity;

namespace HRM_SuThanhHoa.Controllers
{
    [Route("ii")]
    public class ProjectAPI : BaseController
    {
        private readonly IProjectService _projectService;
        private readonly IRepository<User> repository;
        public ProjectAPI(IProjectService projectService, IRepository<User> userRepository)
        {
            _projectService = projectService;
            repository = userRepository;

        }
        [HttpGet("a")]
        public async Task<IActionResult> GetAl8l()
        {
            return Ok(await _projectService.GetAll());
        }
       
    }
}
