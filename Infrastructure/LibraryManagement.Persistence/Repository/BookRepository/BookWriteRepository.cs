using LibraryManagement.Application.Repository.BookRepository;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Persistence.Repository.BookRepository
{
    public class BookWriteRepository : WriteRepository<Book>, IBookWriteRepository
    {
        public BookWriteRepository(LibraryManagementDbContext context) : base(context)
        {
        }
    }
}
