using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CoreApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Query.ContainsKey("id"))
                {
                    if (int.Parse(context.Request.Query["id"]) == 5)
                    {
                        await next();
                    }
                    else await context.Response.WriteAsync("Not Authenticated");
                }
                else
                {
                    await context.Response.WriteAsync("Not Authenticated");
                }
                //await context.Response.WriteAsync("later execution middleware \n");
            });
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from Last Middleware");
            //});
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context => {
                    await context.Response.WriteAsync("Hello From Index");
                });
                endpoints.MapGet("/route", async context => {
                    await context.Response.WriteAsync("Hello From Route ");
                });
            });
        }
    }
}