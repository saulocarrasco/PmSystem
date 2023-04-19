using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using PmSystem.Domain.Validators;

namespace PmSystem.Infrastructure.Glue.Validator
{
    public static class FluentValidatorExtension
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddFluentValidation(options =>
            {
                // Validate child properties and root collection elements
                options.ImplicitlyValidateChildProperties = true;
                options.ImplicitlyValidateRootCollectionElements = true;
                // Automatic registration of validators in assembly
                options.RegisterValidatorsFromAssemblyContaining<CustomerValidator>();
                options.RegisterValidatorsFromAssemblyContaining<ProductValidator>();
                options.RegisterValidatorsFromAssemblyContaining<CustomerItemValidator>();
            });
        }
    }
}
