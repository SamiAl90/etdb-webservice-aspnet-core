using System.Linq;
using System.Reflection;
using Autofac;
using AutoMapper;
using ETDB.API.ServiceBase.Builder;
using ETDB.API.ServiceBase.Constants;
using ETDB.API.WebService.Data;
using ETDB.API.WebService.Misc.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;

namespace ETDB.API.WebService.Bootstrap
{
    public class Startup
    {
        private readonly IHostingEnvironment environment;
        private readonly IConfigurationRoot configurationRoot;

        private const string CorsName = "AllowAll";
        private readonly string logPath = $"Logs/{Assembly.GetEntryAssembly().GetName().Name}.log";
        private const string SeqPath = "http://localhost:5341";

        private const string SwaggerDocDescription = "ETDB " + ServiceNames.WebService + " V1";
        private const string SwaggerDocVersion = "v1";
        private const string SwaggerDocJsonUri = "/swagger/v1/swagger.json";

        private const string AssemblyPrefix = "ETDB.API.WebService";

        private const string AuthenticationSchema = "Bearer";

        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            this.configurationRoot = builder.Build();

            this.environment = environment;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.RollingFile(this.logPath)
                .WriteTo.Seq(Startup.SeqPath)
                .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(Startup.SwaggerDocVersion, new Info
                {
                    Title = Startup.SwaggerDocDescription,
                    Version = Startup.SwaggerDocVersion
                });
            });

            services.AddAuthentication(Startup.AuthenticationSchema)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = ServiceNames.WebService;
                });

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(RessourceNotFoundExceptionFilter));
                options.Filters.Add(typeof(ActionLogFilter));
                options.Filters.Add(typeof(ErrorLogFilter));

                options.Filters.Add(
                    new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));

            }).AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddDbContext<WebServiceContext>()
                .AddEntityFrameworkSqlServer();

            services.AddCors(options =>
            {
                options.AddPolicy(Startup.CorsName, policyOptions =>
                {
                    policyOptions.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowCredentials();
                });
            });

            services.Configure<MvcOptions>(options => 
                options.Filters.Add(new CorsAuthorizationFilterFactory(Startup.CorsName)));

            services.AddAutoMapper(DependencyContext
                .Default
                .CompileLibraries
                .SelectMany(lib => lib.Assemblies)
                .Where(assemblyName => assemblyName.StartsWith(Startup.AssemblyPrefix))
                .Select(assemblyName => Assembly.Load(assemblyName.Replace(".dll", ""))));
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            if (this.environment.IsDevelopment())
            {
                loggerFactory.AddConsole(this.configurationRoot.GetSection("Logging"));
                loggerFactory.AddDebug();

                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            loggerFactory.AddSerilog();

            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseSwagger();
            app.UseSwaggerUI(action =>
            {
                action.SwaggerEndpoint(Startup.SwaggerDocJsonUri, Startup.SwaggerDocDescription);
            });

            app.UseAuthentication();

            app.UseMvc();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            new ServiceContainerBuilder(builder)
                .UseGenericRepositoryPattern<WebServiceContext>()
                .UseEnvironment(this.environment)
                .UseConfiguration(this.configurationRoot)
                .RegisterTypeAsSingleton<HttpContextAccessor, IHttpContextAccessor>();
        }
    }
}
