using InventarioTiWS.Data.Models;
using InventarioTiWS.Interfaces;
using InventarioTiWS.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioTiWS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IUsuario, UsuarioService>();
            services.AddScoped<IItem, ItemService>();

            services.AddControllers().AddNewtonsoftJson(
                               options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                           );
            services.AddSwaggerGen(c =>
            {
              //  c.SwaggerDoc("v1", new OpenApiInfo { Title = "INVENTARIOTI_BACKEND_API", Version = "v1" });
            });

            services.AddDbContext<InventarioWebContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:InventarioTIWebDB"]));

            //var connection = @"Server=10.0.0.60;Database=Eisa;Trusted_Connection=True;Connection Timeout=30;";
            // services.AddDbContext<EisaContext>(options => options.UseSqlServer(connection));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EISA_BACKEND_API v1"));
            }
            app.UseCors("CorsPolicy");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
