using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleLoan.DataAccessLayer.Repository.Abstraction;
using VehicleLoan.DataAccessLayer.Repository.Implementation;


namespace VehicleLoanAPI
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
            services.AddSingleton<IVehicleDao, VehicleDaoImpl>();
            services.AddSingleton<IApplicantDetailsDao, ApplicantDetailsDaoImpl>();
            services.AddSingleton<ILoanSchemeDao, LoanSchemeDaoImpl>();
            services.AddSingleton<IUserRegistrationDao, UserRegistrationDaoImpl>();
            services.AddSingleton<ILoanDetailsDao, LoanDetailsDaoImpl>();
            services.AddControllers();
            services.AddSingleton<IJwtTokenManager, JwtTokenManager>();
            //this will add services for authentication purpose in web API applucation
            //we are configuring the authentication service to use Jwt authentication scheme
            Action<AuthenticationOptions> action = (AuthenticationOptions options) =>
            {
                options.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            };
            var authenticationBuilder = services.AddAuthentication(action);

            //configuring validation of Jwt Bearer token
            Action<JwtBearerOptions> jwtAction = (JwtBearerOptions options) =>
            {
                TokenValidationParameters tokenValidationConfig = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
                options.TokenValidationParameters = tokenValidationConfig;
            };

            //dependency injection of services for JwtBearer token validation
            authenticationBuilder.AddJwtBearer(jwtAction);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Action<CorsPolicyBuilder> action = (CorsPolicyBuilder builder) =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            };
            app.UseCors(action);
            app.UseRouting();
            //add this line
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
