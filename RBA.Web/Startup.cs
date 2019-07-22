using RBA.ApplicationExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RBA.Data;
using RBA.Data.Repository;
using RBA.Data.Repository.Interfaces;
using System;

namespace RBA
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddLogging();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<RolesDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());

            services.AddDbContext<RolesDbContext>(options => options = dbContextOptionsBuilder);
         
            var rolesDBContext = new RolesDbContext(dbContextOptionsBuilder.Options);

            DatabaseContext.Initialize(rolesDBContext);

            services.AddTransient<IResourceRepository>( s => new ResourceRepository(rolesDBContext));
            services.AddTransient<IResourceRoleMappingRepository>(s => new ResourceRoleMappingRepository(rolesDBContext));
            services.AddTransient<IUserRepository>(s => new UserRepository(rolesDBContext));
            services.AddTransient<IUserRolesMappingRepository>(s => new UserRolesMappingRepository(rolesDBContext));
            services.AddTransient<IActionTypeRoleRepository>(s => new ActionTypeRoleRepository(rolesDBContext));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthenticationMiddleware();

            app.UseAuthorizationMiddleware();

            app.UseMvc();
        }
    }
}
