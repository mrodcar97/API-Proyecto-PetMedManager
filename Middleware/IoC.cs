using Microsoft.Extensions.DependencyInjection;
using System;
using Services;
using Domain;
using Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DataContext;

namespace Middleware;

public static class IoC
{
    private static ServiceProvider _serviceProvider;
    public static IConfiguration Configuration { get; }

    public static void Initialize()
    {
        var services = new ServiceCollection();

        // Aquí registras tus servicios
        services.AddDbContext<DbContext, DataBaseContext>();
        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<IUserRepository, UserRepository>();


        _serviceProvider = services.BuildServiceProvider();
    }

    public static T GetService<T>()
    {
        return _serviceProvider.GetService<T>();
    }
}

