using HRM_Design.Common;
using HRM_Design.Entities.ProjectEntity;
using HRM_Design.Entities.UserEntity;
using HRM_Infrastructure.DataEx;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRM_SuThanhHoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectServices<Project> repository;
        private readonly AppDbContext _dbContext;

        public ProjectController(ProjectServices<Project> userRepository, AppDbContext dbContext)
        {
            repository = userRepository;
            _dbContext = dbContext;

        }
        [HttpPost("AddAsync")]
        public async Task<IActionResult> Add(Project project)
        {
            if (project == null)
            {
                return BadRequest("lỗi");
            }
            await repository.AddAsync(project);
            return Ok("oke");
        }
        [HttpPost("AddRangeAsync/batchSize")]

        public async Task<IActionResult> addRangeAsync(IEnumerable<Project> projects, int batchSize)
        {
            if (projects == null)
            {
                return BadRequest("Lỗi");
            }
            await repository.AddRangeAsync(projects, batchSize);
            return Ok("oke");
        }

        [HttpDelete("Delete/id")]
        public async Task<IActionResult> deleteUser(int id)
        {
            if (id == null)
            {
                return BadRequest("Lỗi");
            }
            else
            {
                await repository.DeleteAsync(id);
                return Ok("oke");
            }
        }

        [HttpDelete("DeleteRangeAsync")]
        public async Task<IActionResult> deleteUseRange(IEnumerable<Project> projects)
        {
            if (projects == null)
            {
                return BadRequest("Lỗi");
            }
            else
            {
                await repository.DeleteRangeAsync(projects);
                return Ok("oke");
            }
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateUse(Project project)
        {
            if (project == null)
            {
                return BadRequest("Lỗi");
            }
            else
            {
                await repository.UpdateAsync(project);
                return Ok("oke");
            }
            }

        [HttpPut("UpdateRangeAsync")]
        public async Task<IActionResult> UpdateUseRange(IEnumerable<Project> projects)
        {
            if (projects == null)
            {
                return BadRequest("Lỗi");
            }
            else
            {
                await repository.UpdateRangeAsync(projects);
                return Ok("oke");
            }
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (id == null)
            {
                return BadRequest("Lỗi");
            }
            else
            {
                await repository.GetByIdAsync(id);
                return Ok("oke");
            }
        }
        [HttpGet("GetALL")]
        public IActionResult getAll()
        {
            var res = repository.GetAll();
            return Ok(res);
        }
        [HttpGet("getFilter")]
        public async Task<IActionResult> GetFilter( string? name,  int pageIndex, int pageSize)
        {
            var query = _dbContext.qa_projects.AsQueryable();
          
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(user => user.ProjectName == name);
            }
            // Không áp dụng phân trang nếu pageSize <= 0
            if (pageSize <= 0)
            {
                var filteredData = await query.ToListAsync();
                return Ok(filteredData);
            }

            // Phân trang
            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var filteredDataWithPaging = await query.ToListAsync();

            return Ok(filteredDataWithPaging);
        }

    }
}
