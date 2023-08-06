using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using System.Reflection;

using TaxCalculator.Application.Commands;
using TaxCalculator.Domain.Interfaces;
using TaxCalculator.Infrastructure;
using TaxCalculator.Infrastructure.Repositories;

namespace TaxCalculator.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Initiate all configuration sources.
            builder.Configuration
            .SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();

            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddUserSecrets<Program>();
            }

            // Add services to the container.
            builder.Services.AddDbContext<TaxCalculatorDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            builder.Services.AddScoped<ITaxBandRepository, TaxBandRepository>();
            builder.Services.AddMediatR(opt =>
            {
                opt.RegisterServicesFromAssemblyContaining<TaxCalculationCommand>();
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt =>
            {
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("AllCors",
                    b =>
                    {
                        b.AllowAnyMethod().AllowAnyHeader()
                        .AllowAnyOrigin();
                    });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllCors");
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}