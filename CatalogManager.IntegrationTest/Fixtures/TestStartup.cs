using CatalogManager.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogManager.IntegrationTest.Fixtures
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        { }

        public override void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<CatalogManagerDbContext>(options =>
                options.UseInMemoryDatabase("CatalogManagerDB_Test"));
        }
    }
}
