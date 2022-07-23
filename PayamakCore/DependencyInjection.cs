using System;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using PayamakCore.Interface;
using PayamakCore.Services;
using Polly;

namespace PayamakCore;

public static class DependencyInjection
{
    public static IServiceCollection AddPayamakService(this IServiceCollection services)
    {
        services.AddHttpClient("payamak", c =>
        {
            c.BaseAddress = new Uri("https://rest.payamak-panel.com/api/SendSMS/");
            c.Timeout = TimeSpan.FromMinutes(1);

        }).AddTransientHttpErrorPolicy(x
            =>
        {
            x.OrResult(r => r.StatusCode >= HttpStatusCode.InternalServerError);

            return x.WaitAndRetryAsync(3, _ =>
                TimeSpan.FromMilliseconds(1000));
        });
        
        services.AddTransient<IPayamakServices, PayamakServices>();

        return services;
    }
}