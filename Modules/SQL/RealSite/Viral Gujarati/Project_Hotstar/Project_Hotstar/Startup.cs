using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Project_Hotstar.Repo.IRepository;
using Project_Hotstar.Repo.Repository;
using Project_Hotstar.Models;
using System.Text;
using Project_Hotstar.Authentication;
using Project_Hotstar.Repo.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project_Hotstar.Models.Authentication;
using Microsoft.AspNetCore.Identity;


namespace Project_Hotstar
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
            services.AddControllers();

            // for dbContext
            services.AddDbContext<HotstarDBContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ConnStr")));

            // For identity
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<HotstarDBContext>().AddDefaultTokenProviders();

            // Adding Authentication and Adding Jwt Bearer
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidAudience = Configuration["JWT:Audience"],
                    ValidIssuer = Configuration["JWT:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };

            });

            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<ISubscriptionRepo, SubscriptionRepo>();
            services.AddTransient<IGenre, GenreRepo>();
            }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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