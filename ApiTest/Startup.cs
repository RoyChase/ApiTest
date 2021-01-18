using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApiTest
{
    public class Startup
    {
        private readonly IDbConnection connection;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            connection = new SqliteConnection("Data Source=InMemorySample;Mode=Memory;Cache=Shared");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            
            services.AddSingleton(connection);

            services.AddSingleton<Context>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Context ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ctx.CreateTable<Customer>();
            ctx.CreateTable<CustomerEmail>();

            var c1 = ctx.Insert(new Customer { Name = "Cust1" });
            var c2 = ctx.Insert(new Customer { Name = "Cust2" });

            ctx.Insert(new CustomerEmail { CustomerId = c1, Email = "ab@cde.com" });
            ctx.Insert(new CustomerEmail { CustomerId = c1, Email = "ef@ghi.com" });
            ctx.Insert(new CustomerEmail { CustomerId = c2, Email = "gh@jkl.com" });
        }
    }
}
