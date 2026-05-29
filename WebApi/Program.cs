using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddScoped<CategoryRepository>();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(@"Server=WIN-9PN4AK695QF\SQLEXPRESS;Database=WebApi;Trusted_Connection=True;TrustServerCertificate=True;"));

            builder.Services.AddControllers();

            var app = builder.Build();

            

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
