using Application.Interfaces;
using Application.Services;
using Domain.BusinessRules;
using Domain.Entities;
using Domain.MessagesBrokerInterfaces;
using Domain.RepositoryInterfaces;
using Domain.Serializer;
using Domain.UnitOfWorkInterfaces;
using FluentValidation;
using Infraestructure.DataAccess.Data;
using Infraestructure.MessagesBroker;
using Infraestructure.Repositories;
using Infraestructure.UnitsOfWork;
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

            // DB Context SQL Server
            builder.Services.AddDbContext<ToysAndGamesDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("ToysAndGamesDataBase")
                    ));

            // DB Context Cosmos
            var toysAndGamesCosmosOptions = 
                new DbContextOptionsBuilder<ToysAndGamesCosmosDbContext>()
                .UseCosmos(
                    builder.Configuration.GetConnectionString("ToysAndGamesDataBaseCosmosDB"),
                    builder.Configuration["CosmosDBNames:ToysAndGames"]
                    );

            builder.Services.AddDbContext<ToysAndGamesCosmosDbContext>(options =>
                options.UseCosmos(
                    builder.Configuration.GetConnectionString("ToysAndGamesDataBaseCosmosDB"),
                    builder.Configuration["CosmosDBNames:ToysAndGames"]
                    ));

            ToysAndGamesCosmosDbContext.CheckAndSeedDatabaseAsync(toysAndGamesCosmosOptions.Options);

            // FluentValidations
            builder.Services.AddScoped<IValidator<Product>, ProductsValidators>();

            // Automapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Dependency Injection
            builder.Services.AddScoped<IProductsService, ProductsService>();
            builder.Services.AddScoped(typeof(IRepositorySQL<>), typeof(RepositorySQL<>));
            builder.Services.AddScoped(typeof(IRepositoryCosmosDB<>), typeof(RepositoryCosmosDB<>));
            builder.Services.AddScoped<IUnitOfWorkSQL, UnitOfWorkSQL>();
            builder.Services.AddScoped<IUnitOfWorkCosmosDB, UnitOfWorkCosmosDB>();
            builder.Services.AddScoped<IPublisher, RabbitMQPublisher>();
            builder.Services.AddTransient<ISerializer, Serializer>();

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