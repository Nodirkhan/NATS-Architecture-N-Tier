using Application.OrganizationEvent;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using Infrastructure.NATSConsumer;

using NATS.Client;

namespace FirstApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                ConfigurenNats(builder);
            });

            builder.Services.AddCors();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<ICosumer, Consumer>();
            builder.Services.AddTransient<IOrganizationEvent, OrganizationEvent>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
            app.Services.GetService<IOrganizationEvent>().ListenOrganizationEvent();

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