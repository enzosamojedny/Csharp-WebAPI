
using Microsoft.EntityFrameworkCore;
using Web_API_Proyecto_final.Database;
using Web_API_Proyecto_final.Services;
namespace Web_API_Proyecto_final
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer("Server=.; Database=NewCoderDB;Trusted_Connection=True;TrustServerCertificate=true;");
            });
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<ProductService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
