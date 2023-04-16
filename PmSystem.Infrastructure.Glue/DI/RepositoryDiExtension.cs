﻿using Microsoft.Extensions.DependencyInjection;
using PmSystem.Domain.Contracts;
using PmSystem.Domain.Entities;
using PmSystem.Infrastructure.Data;

namespace PmSystem.Infrastructure.Glue.DI
{
    public static class RepositoryDiExtension
    {
        public static void Configure(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<Product>), typeof(Repository<Product>));
            services.AddTransient(typeof(IRepository<Customer>), typeof(Repository<Customer>));
        }
    }
}