using HRM_Design.Common;
using HRM_Design.Entities.UserEntity;
using HRM_Design.IService.IProjectService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRM_Infrastructure.DataEx;
using Microsoft.EntityFrameworkCore;

namespace HRM_SuThanhHoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices<User> repository;
        private readonly AppDbContext _dbContext;
        public UserController(UserServices<User> userRepository, AppDbContext dbContext)
        {
            repository = userRepository;
            _dbContext = dbContext;

        }
        [HttpPost("AddAsync")]
        public async Task<IActionResult> Add(User user)
        {
            if (user == null)
            {
                return BadRequest("lỗi");
            }
            await repository.AddAsync(user);
            return Ok("oke");
        }
        [HttpPost("AddRangeAsync/batchSize")]

         public async Task<IActionResult> addRangeAsync(IEnumerable<User> user, int batchSize) { 
            if (user == null)
            {
                return BadRequest("Lỗi");
            }
            await repository.AddRangeAsync(user,batchSize);
            return Ok("oke");
        }

        [HttpDelete("Delete/id")]
        public async Task<IActionResult> deleteUser(int id)
        {
            if(id == null)
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
        public async Task<IActionResult> deleteUseRange(IEnumerable<User> user)
        {
            if (user == null)
            {
                return BadRequest("Lỗi");
            }
            else
            {
                await repository.DeleteRangeAsync(user);
                return Ok("oke");
            }
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateUse(User user)
        {
            if (user == null)
            {
                return BadRequest("Lỗi");
            }
            else
            {
                await repository.UpdateAsync(user);
                return Ok("oke");
            }
        }

        [HttpPut("UpdateRangeAsync")]
        public async Task<IActionResult> UpdateUseRange(IEnumerable<User> user)
        {
            if (user == null)
            {
                return BadRequest("Lỗi");
            }
            else
            {
                await repository.UpdateRangeAsync(user);
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
        public async Task<IActionResult> GetFilter(string? email, string? fisrtName, string? address, int pageIndex, int pageSize)
        {
            var query = _dbContext.qa_users.AsQueryable();

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(user => user.Email == email);
            }

            if (!string.IsNullOrEmpty(fisrtName))
            {
                query = query.Where(user => user.FisrtName == fisrtName);
            }

            if (!string.IsNullOrEmpty(address))
            {
                query = query.Where(user => user.Address == address);
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
