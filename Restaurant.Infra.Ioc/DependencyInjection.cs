﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Mappings;
using Restaurant.Application.Services;
using Restaurant.Domain.Interfaces;
using Restaurant.Infra.Data.Context;
using Restaurant.Infra.Data.Repositories;

namespace Restaurant.Infra.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration
            .GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        
        services.AddScoped<IMenuItemRepository, MenuItemRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IMenuItemService, MenuItemService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
        
        var handlers = AppDomain.CurrentDomain.Load("Restaurant.Application");
        services.AddMediatR(handlers);

        return services;
    }
}