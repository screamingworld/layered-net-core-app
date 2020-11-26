using AutoMapper;
using FluentValidation;
using FluentValidation.Application.Validators;
using Layered.Application.Contract.Models;
using Layered.Application.Contract.Services;
using Layered.Application.Mapping;
using Layered.Application.Services;
using Layered.Business.Contract.Abstractions;
using Layered.Business.Services;
using Layered.DataLayer.Contract.Abstractions;
using Layered.DataLayer.Contract.Entities;
using Layered.DataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Layered.WebApi.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IItemService, ItemService>();
            serviceCollection.AddSingleton<IValidator<ItemModel>, ItemModelValidator>();

            serviceCollection.AddAutoMapper((srv, cfg) =>
            {
                cfg.AddProfile(typeof(MappingProfile));
            },
            new Assembly[0], ServiceLifetime.Singleton);

            return serviceCollection;
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IItemDataService, ItemDataService>();

            return serviceCollection;
        }

        public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IRepository<ItemEntity>, ItemRepository>();

            return serviceCollection;
        }
    }
}
