using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyApi;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            
            // 健康检查端点
            endpoints.MapGet("/health", async context =>
            {
                await context.Response.WriteAsync("OK");
            });
            
            // 根路径
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Hello from .NET API! Deployed automatically via GitHub Actions.");
            });
        });
    }
}
