﻿using IdentityServer.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityServer;

public class Startup
{
    public IWebHostEnvironment Environment
    {
        get;
    }

    public Startup(IWebHostEnvironment environment)
    {
        Environment = environment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // uncomment, if you want to add an MVC-based UI
        //services.AddControllersWithViews();

        var builder = services.AddIdentityServer()
                                .AddDeveloperSigningCredential()        //This is for dev only scenarios when you don’t have a certificate to use.
                                .AddInMemoryApiScopes(Config.ApiScopes)
                                .AddInMemoryClients(Config.Clients)
                                .AddCustomUserStore();
    }

    public void Configure(IApplicationBuilder app)
    {
        if (Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // uncomment if you want to add MVC
        //app.UseStaticFiles();
        //app.UseRouting();

        app.UseIdentityServer();

        // uncomment, if you want to add MVC
        //app.UseAuthorization();
        //app.UseEndpoints(endpoints =>
        //{
        //    endpoints.MapDefaultControllerRoute();
        //});
    }
}
