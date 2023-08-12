using HRM_Design.Common;
using HRM_Design.IService.IProjectService;
using HRM_Design.Service.ProjectService;
using HRM_Infrastructure.DataEx;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;

namespace HRM_SuThanhHoa
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                // Thay "UseYourDatabaseProvider()" bằng phương thức sử dụng database provider của bạn (ví dụ: UseSqlServer, UseMySQL, ...)
                options.UseSqlServer("Server=localhost;Integrated Security=true;Initial Catalog=dbThanhHoaSu;MultipleActiveResultSets=True;encrypt=true;trustservercertificate=true");
            });
            builder.Services.AddScoped(typeof(IRepository<>), typeof(ExRepository<>));
            builder.Services.AddScoped(typeof(UserServices<>));
            builder.Services.AddScoped(typeof(ProjectServices<>));
            builder.Services.AddScoped(typeof(AttenDancesSerVices<>));
            builder.Services.AddScoped<IProjectService, ProjectService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting(); // Thêm dòng này để cho phép routing

            app.UseCors(builder => builder // Thêm cấu hình CORS vào đây
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
