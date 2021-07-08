using Hotstar_API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

using Microsoft.OpenApi.Models;

using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Hotstar_API.Models.Authentication;
using Hotstar_API.Repository.IGenericRepository;
using Hotstar_API.Repository.GenericRepository;
using Hotstar_API.Service.Email;

namespace Hotstar_API
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
            //registering repository
            services.AddControllers();
            services.AddTransient<IMailService, MailService>();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddEntityFrameworkSqlServer();

            services.AddTransient<ICategory, CategoryRepo>();
            services.AddTransient<IContent, ContentRepo>();
            services.AddTransient<IPlan, PlanRepo>();
            services.AddTransient<IShow, ShowRepo>();
            services.AddTransient<ISubcategory, SubcategoryRepo>();
            services.AddTransient<ISubscriptionPriceList, SubscriptionPriceListRepo>();
            services.AddTransient<ISubscriptionDetail,SubscriptionDetailRepo>();
            services.AddTransient<IUserAccount,UserAccountRepo>();
            services.AddTransient<IVFreeMovie,VFreeMovieRepo>();
            services.AddTransient<IVMovie,VMovieRepo>();
            services.AddTransient<IVPremiumMovie,VPremiumMovieRepo>();
            services.AddTransient<IVSport,VSportRepo>();



            // Entity FrameWork 
            
            services.AddDbContext<HOTSTARDATAContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnStr")));

           
            //// For Identity  

            //step 3  
            services.AddIdentity<ApplicationUser, IdentityRole> (config => {
                config.SignIn.RequireConfirmedEmail = true;


            } ).AddEntityFrameworkStores<HOTSTARDATAContext>()
            .AddDefaultTokenProviders();

            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))

                };
            });
            
            
            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hotstar_API", Version = "v1" });
            });


            

            services.AddCors();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(options =>
            options.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotstar_API v1"));
            }

            app.UseHttpsRedirection();

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
