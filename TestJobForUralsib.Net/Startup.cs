using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using TestJobForUralsib.Domain.Data;
using TestJobForUralsib.Domain.DTOs.mapping;
using TestJobForUralsib.Domain.Models;
using TestJobForUralsib.Domain.Services;
using TestJobForUralsib.Domain.Services.Interfaces;

namespace TestJobForUralsib.Net
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
            services.AddMvc();

            //technical DI
            services.AddDbContext<TestJobForUralsibDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IMapper, Mapper>(InitializeAutomapper.GetInstance);

            //DI
            services.AddScoped<ICustomersService, CustomersService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                var scope = app.ApplicationServices.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<TestJobForUralsibDbContext>();

                if (context.Customers.Count() == 3)
                {
                    var c = new Customer("test-name-4", "test-surname-4", "test-patronymic-4")
                    {
                        Information = new CustomerExtraInformation("test-phone-4")
                    };

                    context.Customers.Add(c);

                    context.SaveChanges();
                }
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
