
using FacturadorAPI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace FacturadorAPI
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

            var connectionString = builder.Configuration.GetConnectionString("FacturadorDB");

            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

            builder.Services.AddScoped<ClienteService>();
            builder.Services.AddScoped<Factura_CabeceraService>();
            builder.Services.AddScoped<Factura_DetalleService>();
            builder.Services.AddScoped<ArticuloService>();

            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().CreateLogger();

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
