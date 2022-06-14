using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Sockets;
using WebApi.Data;

namespace WebApi
{
    public class Program
    {
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }               
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
                var dbUrl = Environment.GetEnvironmentVariable("DATABASE_URL") ?? "";                
                var connStr = config.GetConnectionString("DefaultConnection");                
                options.UseSqlServer(!string.IsNullOrEmpty(dbUrl)
                    ? dbUrl
                    : connStr);
            },ServiceLifetime.Scoped);
            //builder
            var app = builder.Build();            
            // Configure the HTTP request pipeline.            
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}