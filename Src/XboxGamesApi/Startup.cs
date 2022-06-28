using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XboxGamesApi.Extensions;
using XboxGamesApi.Helpers;

namespace XboxGamesApi
{
    public class Startup
    {

        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        //public IConfiguration Configuration { get; }

        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers();


            //implementar melhoria no contexto dos database futuramente
            services.AddDbContext<AppIdentityDbContext>(options =>
                           options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));

            services.AddDbContext<SqlDbContext>(options =>
               options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
            //

            services.AddAppServices();
            services.AddIdentityServices(_config);
            services.AddSwaggerDoc();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles(); //necessario talves ?

            app.UseAuthorization();

            app.UseSwaggerDoc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
