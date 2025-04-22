using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Repository.AuthorRepository
{
    public interface IAuthorWriteRepository:IWriteRepository<Author>
    {
    }
}
