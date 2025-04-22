using LibraryManagement.Application.Repository.AuthorRepository;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Persistence.Repository.AuthorRepository
{
    public class AuthorWriteRepository : WriteRepository<Author>, IAuthorWriteRepository
    {
        public AuthorWriteRepository(LibraryManagementDbContext context) : base(context)
        {
        }
    }
}
