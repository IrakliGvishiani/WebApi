using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WebApi.Data;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();






            //builder.Services.AddScoped<CategoryRepository>();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(@"Server=WIN-9PN4AK695QF\SQLEXPRESS;Database=EcommerceWebApi;Trusted_Connection=True;TrustServerCertificate=True;"));
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", policy =>
                {
                    policy
           .AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
                });
            });

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1",
                    Description = "This is my API description"
                });

                #region XML Documentation
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
                #endregion
            });

  


            var app = builder.Build();

            
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseCors("MyPolicy");
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
