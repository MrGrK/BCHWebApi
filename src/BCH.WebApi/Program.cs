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
using System.Text.Json.Serialization;
using BCH.Application.Behaviors;
using Serilog;

namespace BCH.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter() ));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen((sw) =>
            {
                sw.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Blockchain Info", Version = "v1" });

                var fileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);

                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => sw.IncludeXmlComments(xmlFile));
            });

            var blockcyApiOptions = new BlockcyApiSettings();
            builder.Configuration.GetSection(BlockcyApiSettings.BlockcyApi).Bind(blockcyApiOptions);
            builder.Services.AddSingleton(blockcyApiOptions);

            builder.Services.AddScoped<IBlockchainRepository, BlockchainRepository>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddHttpClient<IBlockcypherClient, BlockcypherClient>((client) =>
            {
                client.BaseAddress = new Uri(blockcyApiOptions.ApiEndpoint);
            });

            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("BCH.Application")));

            builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Host.UseSerilog((context, config) =>
                config
                    .WriteTo.Console()
                    .ReadFrom.Configuration(context.Configuration)
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}