// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using ParusRx.DirectumRx.Integration.Stores;
using Serilog;
using System;

public static partial class Program
{
    public const string AppName = "DirectumRx";

    /// <summary>
    /// Adds Serilog to the specified <see cref="WebApplicationBuilder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/>.</param>
    public static void AddCustomSerilog(this WebApplicationBuilder builder)
    {
        var seqServerUrl = builder.Configuration["Serilog:SeqServerUrl"];
        var logstashUrl = builder.Configuration["Serilog:LogstashUrl"];

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Enrich.WithProperty("ApplicationContext", AppName)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.Seq(string.IsNullOrWhiteSpace(seqServerUrl) ? "http://seq" : seqServerUrl)
            .WriteTo.Http(string.IsNullOrWhiteSpace(logstashUrl) ? "http://logstash:8080" : logstashUrl, queueLimitBytes: null)
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();
    }

    /// <summary>
    /// Adds Health Check services to the specified <see cref="WebApplicationBuilder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/>.</param>
    public static void AddCustomHealthCheck(this WebApplicationBuilder builder)
    {
        var hcBuilder = builder.Services.AddHealthChecks();

        hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy());

        var provider = builder.Configuration["Database:Provider"];
        if (provider == "Oracle")
        {
            hcBuilder.AddOracle(
                builder.Configuration["Database:ConnectionString"],
                name: "Oracle Database Connection",
                tags: new string[] { "oracle" });
        }
        else if (provider == "Postgres")
        {
            hcBuilder.AddNpgSql(
                builder.Configuration["Database:ConnectionString"],
                name: "PostgreSQL Connection",
                tags: new string[] { "postgres" });
        }
    }

    /// <summary>
    /// Adds Swagger services to the specified <see cref="WebApplicationBuilder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/>.</param>
    public static void AddCustomSwagger(this WebApplicationBuilder builder) =>
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Directum RX HTTP API",
                Version = "v1",
                Description = "The Directum RX Microservice HTTP API."
            });
        });

    /// <summary>
    /// Register the Swagger middleware.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/>.</param>
    public static void UseCustomSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint($"/swagger/v1/swagger.json", "DaData API v1");
        });
    }

    /// <summary>
    /// Adds Data Access services to the specified <see cref="WebApplicationBuilder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/>.</param>
    public static void AddCustomDataAccess(this WebApplicationBuilder builder)
    {
        var provider = builder.Configuration["Database:Provider"];

        if (provider == "Oracle")
        {
            builder.Services
                .AddDataAccess(options => options.UseOracle(builder.Configuration["Database:ConnectionString"]))
                .AddOracleParusRxStores();
        }
        else if (provider == "Postgres")
        {
            builder.Services
                .AddDataAccess(options => options.UsePostgreSql(builder.Configuration["Database:ConnectionString"]))
                .AddPostgresParusRxStore();

            AppContext.SetSwitch("Npgsql.EnableStoredProcedureCompatMode", true);
        }
    }

    // <summary>
    /// Adds MVC services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddCustomMvc(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder
                .SetIsOriginAllowed((host) => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
        });

        return services;
    }

    /// <summary>
    /// Provides a common entry point for registering the application services.
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/>.</param>
    public static void AddCustomApplicationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpClient<IDrxPartyService, DrxPartyService>()
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
            });

        var provider = builder.Configuration["Database:Provider"];

        if (provider == "Oracle")
        {
            builder.Services.AddScoped<IDrxSheduledService, DrxOracleSheduledService>();
            builder.Services.AddScoped<IDrxScheduledStore, DrxOracleScheduledStore>();
        }
        else if (provider == "Postgres")
        {
            builder.Services.AddScoped<IDrxSheduledService, DrxPostgresSheduledService>();
            builder.Services.AddScoped<IDrxScheduledStore, DrxPostgresScheduledStore>();
        }

        builder.Services.AddScoped<IDrxPartyEventService, DrxPartyEventService>();
        

        builder.Services.AddTransient<ConnectHandler>();
        builder.Services.AddTransient<BusinessUnitHandler>();
        builder.Services.AddTransient<EmployeeHandler>();
        builder.Services.AddTransient<DocumentTypeKindHandler>();
        builder.Services.AddTransient<PackagesLifeCycleStateHandler>();
        builder.Services.AddTransient<UserTokenHandler>();
        builder.Services.AddTransient<PackagesHandler>();
        builder.Services.AddTransient<ContractCategoryHandler>();
        builder.Services.AddTransient<DocumentRegisterHandler>();
    }
}
