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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using BackEnd.Models.Authentication;
using BackEnd.Models.Repository.UserRepository;

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


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.RequireHttpsMetadata = false;
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = AuthOptions.ISSUER,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = AuthOptions.AUDIENCE,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,

                            // установка ключа безопасности
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                       };
                   });

            services.AddScoped<IGenericRepository<Country>,CountryRepository>();
            services.AddScoped<IGenericRepository<Genre>, GenreRepository>();
            services.AddScoped<IGenericRepository<Localization>, LocalizationRepository>();
            services.AddScoped<IGenericRepository<Manufacture>, ManufactureRepository>();
            services.AddScoped<IGenericRepository<Platform>, PlatformRepository>();
            services.AddScoped<IGenericRepository<Role>, RoleRepository>();
            services.AddScoped<IGenericRepository<Serie>, SeriesRepository>();
            services.AddScoped<IGenericRepository<Statuse>, StatuseRepository>();
            services.AddTransient<IUserRepository,UserRepositoryImpl>();
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

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
