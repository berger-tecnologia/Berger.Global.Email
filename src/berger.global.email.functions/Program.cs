using System;
using MediatR;
using Serilog;
using Microsoft.Extensions.Hosting;
using berger.global.email.infra.ioc;
using Microsoft.Extensions.Configuration;
using berger.global.application.AutoMapper;
using berger.global.functions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace berger.global.functions
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices
                (
                    services =>
                    {
                        var serviceProvider = services.BuildServiceProvider();

                        // Configurations
                        var configuration = serviceProvider.GetService<IConfiguration>();
                        var environment = serviceProvider.GetService<IHostEnvironment>();

                        var builder = new ConfigurationBuilder().SetBasePath(environment.ContentRootPath)
                                .AddJsonFile("appsettings.json", true, true)
                                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true);

                        builder.AddEnvironmentVariables();

                        configuration = builder.Build();

                        // Auto mapper
                        services.AddAutoMapper(typeof(DomainViewModelMapping), typeof(ViewModelDomainMapping));

                        // Dependency Injection (Services)
                        services.Register();

                        //Mediator
                        var assembly = AppDomain.CurrentDomain.Load("berger.global.domain");
                        services.AddMediatR(assembly);

                        // Serilog
                        var logger = new LoggerConfiguration()
                            .WriteTo.Console()
                            .WriteTo.Http("https://localhost:44383/v1.0/log-events", httpClient: new CustomHttpClient())
                            .CreateLogger()
                            .ForContext<Program>();

                        services.AddLogging(lb => lb.AddSerilog(logger));
                    })
                .Build();

            host.Run();
        }
    }
}