using BCH.Infrasructure.Clients;
using Microsoft.Extensions.Options;
using BCH.WebApi.Controllers;
using BCH.Infrasructure.Configuration.Options;
using Microsoft.Extensions.DependencyInjection;
using BCH.Infrasructure.Data;
using Microsoft.EntityFrameworkCore;
using BCH.Application.Interfaces.Clients;
using MediatR;
using System.Reflection;
using System.Net.NetworkInformation;
using BCH.Domain.Abstractions;
using BCH.Domain.Interfaces.Repositories;
using BCH.Infrasructure.Data.Repositories;

namespace BCH.WebApi
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

            var blockcyApiOptions = new BlockcyApiSettings();
            builder.Configuration.GetSection(BlockcyApiSettings.BlockcyApi).Bind(blockcyApiOptions);

            builder.Services.AddScoped<IBlockchainRepository, BlockchainRepository>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddHttpClient<IBlockcypherClient, BlockcypherClient>((client) =>
            {
                client.BaseAddress = new Uri(blockcyApiOptions.ApiEndpoint);
            });

            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
            );
           // AppDomain.CurrentDomain.Load("BCH.Application");
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("BCH.Application")));

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