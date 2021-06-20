using System;
using Domain.Entities;
using ExchangeGateway.Services;
using ExchangeGateway.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ExchangeGateway {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            services.AddCors (options => {
                options.AddDefaultPolicy (
                    builder => {
                        builder.WithOrigins ("http://localhost:4200").AllowAnyHeader ().AllowAnyMethod ();
                    });
            });

            services.AddHttpClient<IUserService, UserService> (c =>
                c.BaseAddress = new Uri (Configuration["ApiSettings:UserUrl"]));
            services.AddHttpClient<IProductService, ProductService> (c =>
                c.BaseAddress = new Uri (Configuration["ApiSettings:ProductUrl"]));
            services.AddHttpClient<IReportService, ReportService> (c =>
                c.BaseAddress = new Uri (Configuration["ApiSettings:ReportUrl"]));
            services.AddHttpClient<ICurrencyService, CurrencyService> ();
            services.AddHttpClient<IAprpovalEntityService<MoneyApproval>, ApprovalEntityService<MoneyApproval>> (c =>
                c.BaseAddress = new Uri (Configuration["ApiSettings:AdminUrl"]));
            services.AddHttpClient<IAprpovalEntityService<ProductApproval>, ApprovalEntityService<ProductApproval>> (c =>
                c.BaseAddress = new Uri (Configuration["ApiSettings:AdminUrl"]));
            services.AddControllers ();
            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new OpenApiInfo { Title = "ExchangeGateway", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                app.UseSwagger ();
                app.UseSwaggerUI (c => c.SwaggerEndpoint ("/swagger/v1/swagger.json", "ExchangeGateway v1"));
            }

            //    app.UseHttpsRedirection ();
            app.UseCors (builder => builder
                .AllowAnyOrigin ()
                .AllowAnyMethod ()
                .AllowAnyHeader ());
            app.UseRouting ();
            app.UseAuthorization ();
            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}