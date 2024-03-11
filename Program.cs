
using Microsoft.EntityFrameworkCore;
using Web_API_Proyecto_final.Database;
using Web_API_Proyecto_final.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web_API_Proyecto_final
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            HttpClient httpClient = new HttpClient();
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/api/name ");

            //HttpResponse res = httpClient.SendAsync(req);
            //res.IsSuccessStatusCode = true;
            Console.WriteLine("Hello World!");

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer("Server=.; Database=NewCoderDB;Trusted_Connection=True;TrustServerCertificate=true;");
            });
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<SaleService>();
            builder.Services.AddScoped<ProductSoldService>();
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
