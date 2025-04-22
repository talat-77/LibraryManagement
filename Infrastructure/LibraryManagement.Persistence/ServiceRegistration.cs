using LibraryManagement.Application.Repository.AuthorRepository;
using LibraryManagement.Application.Repository.BookRepository;
using LibraryManagement.Persistence;
using LibraryManagement.Persistence.Context;
using LibraryManagement.Persistence.Repository.AuthorRepository;
using LibraryManagement.Persistence.Repository.BookRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddDbContext<LibraryManagementDbContext>(options => options.UseSqlServer(DatabaseConfiguration.Connectionstring));
            services.AddScoped<IAuthorReadRepository,AuthorReadRepository>().Reverse();
            services.AddScoped<IAuthorWriteRepository,AuthorWriteRepository>().Reverse();
            services.AddScoped<IBookReadRepository, BookReadRepository>().Reverse();
            services.AddScoped<IBookWriteRepository, BookWriteRepository>().Reverse();

        }
    }
}
