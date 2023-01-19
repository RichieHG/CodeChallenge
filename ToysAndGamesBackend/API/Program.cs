using Application.Interfaces;
using Application.Services;
using Domain.BusinessRules;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using FluentValidation;
using Infraestructure.DataAccess.Data;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API
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

            // DB Context
            builder.Services.AddDbContext<ToysAndGamesDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("ToysAndGamesDataBase")
                    ));

            // FluentValidations
            builder.Services.AddScoped<IValidator<Product>, ProductsValidators>();

            // Automapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Dependency Injection
            builder.Services.AddScoped<IProductsService, ProductsService>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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