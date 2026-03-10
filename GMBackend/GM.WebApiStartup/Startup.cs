using GM.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using System.Reflection;
using GM.WebApi.Middleware.Extensions;

namespace GM.WebApiStartup;

public class Startup
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();
    private const string OriginsPolicy = "AllowAllOrigins";

    private readonly IWebHostEnvironment environment;

    public Startup(IWebHostEnvironment environment) =>
        this.environment = environment;

    public void ConfigureServices(IServiceCollection services)
    {
        this.logger.Trace("Web API configuring services at startup");

        if (this.environment.IsDevelopment())
        {
            // Add DEV CORS policy
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
        }
        else
        {
            // TODO: Add production ready cors policy
        }

        services
            .AddControllers()
            .AddApplicationPart(Assembly.GetAssembly(typeof(IWebApiModule)))
            .AddNewtonsoftJson();
    }

    public void Configure(IApplicationBuilder app)
    {
        this.logger.Trace("Web API is starting");

        app.UseRouting();

        if (this.environment.IsDevelopment())
        {
            this.logger.Trace("Starting in developer mode");
            app.UseDeveloperExceptionPage();

            // Add DEV CORS policy
            app.UseCors(OriginsPolicy);
        }
        else
        {
            // TODO: Add production ready cors policy
        }

        app.UseWebApiMiddleware();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
        
        this.logger.Trace("Web API is started");
    }
}
