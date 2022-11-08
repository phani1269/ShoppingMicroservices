using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Product.GrpcService.Context;
using Product.GrpcService.Repository;
using Product.GrpcService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.GrpcService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddDbContext<ProductContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnstr"),
                    providerOptions => providerOptions.EnableRetryOnFailure());
            });
            services.AddDbContext<CouponContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnstr1"),
                    providerOptions => providerOptions.EnableRetryOnFailure());
            });

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICouponRepository, CouponRepository>();

            services.AddAutoMapper(typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ProductService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
