using devboost.Domain.Handles.Commands;
using devboost.Domain.Handles.Commands.Interfaces;
using devboost.Domain.Handles.Queries;
using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Repository;
using devboost.Repository;
using devboost.Repository.Context;
using devboost.Test.Warmup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace devboost.Test.Config
{
    public static class StartInjection
    {
        public static IServiceProvider GetServiceCollection()
        {
            IServiceCollection services = new ServiceCollection();

            IConfiguration configuration = StartConfiguration.Configuration;
            services.AddSingleton(x => configuration);

            services.AddDbContext<DataContext>(options =>
                options.UseInMemoryDatabase(databaseName: "Test"));

            //services.AddDbContext<DataContext>(options =>
            //    options.UseSqlServer(
            //        configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IDroneRepository, DroneRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<ILoginHandler, LoginHandler>();
            services.AddScoped<IUserHandler, UserHandler>();
            services.AddScoped<IClienteHandler, ClienteHandler>();
            services.AddScoped<IClientQueryHandler, ClienteQueryHandler>();

            services.AddScoped<IPedidoHandler, PedidoHandler>();
            services.AddScoped<IDroneHandler, DroneHandler>();

            services.AddScoped<IDataStart, DataStart>();

            var builderServices = services.BuildServiceProvider();

            // Inicia base de dados em memória
            var dataStart = builderServices.GetService<IDataStart>();
            dataStart.Seed();

            return builderServices;
        }
    }
}
