using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace WebApp
{
    public class Startup
    {
        private IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ContadorOptions>(options => {
                options.Quantidade = 5;
            });
            services.Configure<CronometroOptions>(
                configuration.GetSection(nameof(CronometroOptions)));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<ContadorOptions> options)
        {
            app.UseTempoExecucao();

            app.UseWhen(
                context => context.Request.Query.ContainsKey("caminhoC"), appC => {
                    appC.Use(async (context, next) => {
                        await context.Response.WriteAsync("\n Processado pela ramificação C");
                        await next();
                    });
                });

            app.Map("/caminhoB", appB => {
                appB.Run(async context => {
                    await context.Response.WriteAsync("\nProcessada pela Ramificação B");
                });
            });
            
            app.UseWhen(
                context => context.Request.Query.ContainsKey("caminhoC"), appC => {
                    appC.Use(async (context, next) => {
                        await context.Response.WriteAsync("\n Processado pela ramificação C");
                        await next();
                    });
                });

            app.Use(async (context, next) => {
                await context.Response.WriteAsync("===");
                await next();
                await context.Response.WriteAsync("===");
            });
            app.Use(async (context, next) => {

                var contadorOptions = options.Value;
                await context.Response.WriteAsync(new string('>', contadorOptions.Quantidade));
                await next();
                await context.Response.WriteAsync(new string('<', contadorOptions.Quantidade));
            });
            app.Use(async (context, next) => {
                await context.Response.WriteAsync("[[[");
                await next();
                await context.Response.WriteAsync("]]]");
            });
            app.Run(async context => 
            {
                await context.Response.WriteAsync("Middleware Terminal");
            });
        }
    }
}
