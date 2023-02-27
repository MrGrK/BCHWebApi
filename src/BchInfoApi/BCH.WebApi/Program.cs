using BCH.Infrasructure.Clients;
using BCH.Infrasructure.Clients.Interfaces;
using Microsoft.Extensions.Options;
using BCH.WebApi.Controllers;
using BCH.Infrasructure.Configuration.Options;
using Microsoft.Extensions.DependencyInjection;

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

            builder.Services.AddHttpClient<IBlockcypherClient, BlockcypherClient>((client) =>
            {
                client.BaseAddress = new Uri(blockcyApiOptions.ApiEndpoint);
            });

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