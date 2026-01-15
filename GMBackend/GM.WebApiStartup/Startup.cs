using GM.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using System.Reflection;

namespace GM.WebApiStartup;

public class Startup
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();
    private const string OriginsPolicy = "AllowAllOrigins";

    public void ConfigureServices(IServiceCollection services)
    {
        this.logger.Trace("Web API configuring services at startup");

        // Add CORS policy
        services.AddCors(options =>
        {
            options.AddPolicy(OriginsPolicy,
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        services
            .AddControllers()
            .AddApplicationPart(Assembly.GetAssembly(typeof(IWebApiModule)))
            .AddNewtonsoftJson();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        this.logger.Trace("Web API is starting");

        if (env.IsDevelopment())
        {
            this.logger.Trace("Starting in developer mode");
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseCors(OriginsPolicy);

        app.UseEndpoints(endpoints => endpoints.MapControllers());

        this.logger.Trace("Web API is started");
    }
}
