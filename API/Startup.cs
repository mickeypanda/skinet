using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using API.Helpers;
using API.Middlewares;
using AutoMapper;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Configuration of IProductRepository with ProductRepository
            services.AddScoped<IProductRepository, ProductRepository>();
            //Configuration of IgenericRepository with GenericRepository in a f=differetn manner as it is Generic type class
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //configuration of Automapper in the services
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers();
            services.AddDbContext<StoreContext>(x => x.UseSqlite(_configuration.GetConnectionString("DefaultConnection")));

            //Code for setting up the I Enumerable properties for ApiValidation errors.
            services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //This was default provided by application template. If we are using any middleware then we have to provide our middleware 
            //here to make it register for the application
            /*if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }*/

            //here we have registered our middleware class to get the httpresponse according to our requirement.
            //This method is being used instead of the above commented method.
            app.UseMiddleware<ExceptionMiddleware>();

            //This method is used for reexecuting the controllers for the error code type, when they get an error of unknown type or unhandeled type.
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseHttpsRedirection();

            app.UseRouting();

            //for using and sending the static files from the controller services
            //Chronology matters
            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
