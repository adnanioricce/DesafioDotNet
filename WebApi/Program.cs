using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            var config = builder.Configuration;
            //builder.Services.AddControllers();
            builder.Services.AddControllersWithViews();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContextFactory<DataContext>(options =>
            {
                if (builder.Environment.IsDevelopment())
                {
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                }
                var connStr = config.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connStr);
            },ServiceLifetime.Scoped);
            //builder
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}