
using Application.Service;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using Infrastructure.NATS;

using NATS.Client;

namespace SecondApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.WebHost.UseUrls("http://*:7015");
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                ConfigurenNats(builder);
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IOrganizationRequest, OrganizationRequest>();
            builder.Services.AddTransient<IOrganizationService, OrganizationService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        public static void ConfigurenNats(ContainerBuilder builder)
        {
            var options = ConnectionFactory.GetDefaultOptions();
            options.Servers = new string[]
            {
                "nats://localhost:4222"
            };
            options.Password = " ";
            options.User = " ";
            var connection = new ConnectionFactory().CreateConnection(options);
            builder.RegisterInstance(connection);

        }
    }
}