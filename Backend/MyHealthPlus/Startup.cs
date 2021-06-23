using Autofac;
using MyHealthPlus.Helpers;
using MyHealthPlus.Persistence;
using MyHealthPlus.Repository;
using MyHealthPlus.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace MyHealthPlus
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyHealthPlus Backend API", Version = "v1" });
            });
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<MyHealthPlusContext>().As<DbContext>().AsSelf().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().AsSelf().AsImplementedInterfaces();
            builder.RegisterType<AppointmentRepository>().AsSelf().AsImplementedInterfaces();
            builder.RegisterType<UserTypeRepository>().AsSelf().AsImplementedInterfaces();
            builder.RegisterType<AppointmentTypeRepository>().AsSelf().AsImplementedInterfaces();
            builder.RegisterType<SessionRepository>().AsSelf().AsImplementedInterfaces();
            builder.RegisterType<UserService>().AsSelf().AsImplementedInterfaces();
            builder.RegisterType<AppointmentService>().AsSelf().AsImplementedInterfaces();        
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x.AllowAnyMethod()
                              .AllowAnyHeader()
                              .SetIsOriginAllowed(origin => true)
                              .AllowCredentials());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyHealthPlus v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
