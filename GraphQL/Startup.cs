using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using ConferencePlanner.GraphQL;
//using ConferencePlanner.GraphQL.Data;
using Microsoft.EntityFrameworkCore; //for UseSqlite
using DemoDB;
using DemoDB.Impl;
using GraphQL.DI;

namespace GraphQL
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
            //dotnet ef dbcontext scaffold "Filename=Northwind.db" Microsoft.EntityFrameworkCore.Sqlite -o Models -f -c NorthwindbContext  (the Northwind.db should exist in same folder)
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // var appSettingsSection = Configuration.GetSection("AppSettings");
            // services.Configure<AppSettings>(appSettingsSection);
            // services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=conferences.db")
            // .AddUnitOfWork<NorthwindbContext>());
            
             services.AddDbContext<NorthwindbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"))
                ).AddUnitOfWork<NorthwindbContext>();  

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapGraphQL();
            });
        }
    }
}
