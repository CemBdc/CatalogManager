using System.Linq;
using CatalogManager.Business;
using CatalogManager.Business.Contracts;
using CatalogManager.Data.Context;
using CatalogManager.Data.UnitOfWork;
using CatalogManager.Filter;
using CatalogManager.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CatalogManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            services.AddApiVersioning();
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            ConfigureDatabase(services);

            services.AddScoped(typeof(IProduct), typeof(Product));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddSwaggerGen(options =>
            {
                options.EnableAnnotations();

                options.SwaggerDoc("v1",
                    new Info
                    {
                        Version = "v1",
                        Title = "Catalog Manager",
                        Description = "Catalog Manager Version 1(v1) API Documentation",
                        TermsOfService = "Terms of usage v1",
                        Contact = new Contact
                        {
                            Name = "Cem Bideci",
                            Email = "cembdci@gmail.com",
                            Url = "http://linkedin.com/in/cem-bideci",
                        },
                    });
                
                options.SwaggerDoc("v2",
                    new Info
                    {
                        Version = "v2",
                        Title = "Catalog Manager",
                        Description = "Catalog Manager Version 2(v2) API Documentation",
                        TermsOfService = "Terms of usage v2",
                        Contact = new Contact
                        {
                            Name = "Cem Bideci",
                            Email = "cembdci@gmail.com",
                            Url = "http://linkedin.com/in/cem-bideci",
                        },
                    });
                
                options.OperationFilter<RemoveVersionFromParameter>();
                options.DocumentFilter<ReplaceVersionWithExactValueInPath>();
                
                options.DocInclusionPredicate((version, desc) =>
                {
                    var versions = desc.ControllerAttributes()
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions);

                    var maps = desc.ActionAttributes()
                        .OfType<MapToApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions)
                        .ToArray();

                    return versions.Any(v => $"v{v.ToString()}" == version)
                                  && (!maps.Any() || maps.Any(v => $"v{v.ToString()}" == version)); ;
                });

            });
            
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<LoggingMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", $"v1");
                c.SwaggerEndpoint($"/swagger/v2/swagger.json", $"v2");
            });

            app.UseMvc();
        }

        public virtual void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<CatalogManagerDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("CatalogManagerDB")));
        }
    }
}
