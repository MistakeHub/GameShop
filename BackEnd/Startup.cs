using BackEnd.Models.Repository.PublicationRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Models.Repository.GenericRepository;

namespace BackEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public RepositoryType repositoryType;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPublicationRepository, PublicationRepository>();
            services.AddControllers();
            services.AddDbContext<shopContext>(options => options.UseMySql(Configuration.GetConnectionString("shopContex"), new MySqlServerVersion(new Version(8, 0, 11))));
            services.AddControllers().AddNewtonsoftJson(options =>
     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
 );       services.AddCors();
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IGenericRepository<Country>,CountryRepository>();
            services.AddScoped<IGenericRepository<Genre>, GenreRepository>();
            services.AddScoped<IGenericRepository<Localization>, LocalizationRepository>();
            services.AddScoped<IGenericRepository<Manufacture>, ManufactureRepository>();
            services.AddScoped<IGenericRepository<Platform>, PlatformRepository>();
            services.AddScoped<IGenericRepository<Role>, RoleRepository>();
            services.AddScoped<IGenericRepository<Serie>, SeriesRepository>();
            services.AddScoped<IGenericRepository<Statuse>, StatuseRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });
            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
