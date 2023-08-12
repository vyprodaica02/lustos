using HRM_Design.Common;
using HRM_Design.Entities.ProjectEntity;
using HRM_Design.Entities.TimeKeeping;
using HRM_Infrastructure.DataEx;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HRM_SuThanhHoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttenDancesController : ControllerBase
    {
        private readonly AttenDancesSerVices<Attendance> repository;
        private readonly AppDbContext _dbContext;

        public AttenDancesController(AttenDancesSerVices<Attendance> userRepository, AppDbContext dbContext)
        {
            repository = userRepository;
            _dbContext = dbContext;


        }
        [HttpPost("AddAsync")]
        public async Task<IActionResult> Add(Attendance attendance)
        {
            if (attendance == null)
            {
                return BadRequest("lỗi");
            }
            await repository.AddAsync(attendance);
            return Ok("oke");
        }
        [HttpPost("AddRangeAsync/batchSize")]

        public async Task<IActionResult> addRangeAsync(IEnumerable<Attendance> attendances, int batchSize)
        {
            if (attendances == null)
            {
                return BadRequest("Lỗi");
            }
            await repository.AddRangeAsync(attendances, batchSize);
            return Ok("oke");
        }

        [HttpDelete("Delete/id")]
        public async Task<IActionResult> deleteUser(int id )
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
        public async Task<IActionResult> deleteUseRange(IEnumerable<Attendance> attendances)
        {
            if (attendances == null)
            {
                return BadRequest("Lỗi");
            }
            else
            {
                await repository.DeleteRangeAsync(attendances);
                return Ok("oke");
            }
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateUse(Attendance attendance)
        {
            if (attendance == null)
            {
                return BadRequest("Lỗi");
            }
            else
            {
                await repository.UpdateAsync(attendance);
                return Ok("oke");
            }
        }

        [HttpPut("UpdateRangeAsync")]
        public async Task<IActionResult> UpdateUseRange(IEnumerable<Attendance> attendances)
        {
            if (attendances == null)
            {
                return BadRequest("Lỗi");
            }
            else
            {
                await repository.UpdateRangeAsync(attendances);
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
                return Ok();
            }
        }

        [HttpGet("GetALL")]
        public IActionResult getAll()
        {
            var res = repository.GetAll();
            return Ok(res);
        }

        [HttpGet("getFilter")]
        public async Task<IActionResult> GetFilter(int? userId,  int pageIndex, int pageSize)
        {
            var query = _dbContext.qa_attendances.AsQueryable();

            if (userId.HasValue)
            {
                query = query.Where(x => x.UserId == userId);
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
