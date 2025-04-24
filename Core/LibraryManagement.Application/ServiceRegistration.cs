using FluentValidation;
using LibraryManagement.Application.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application
{
    public static class ServiceRegistration 
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateAuthorDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateBookDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateAuthorDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateBookDtoValidator>();
            return services;
            
        }
    }
}
