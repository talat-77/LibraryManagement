using LibraryManagement.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities
{
    public class Author:BaseEntity
    {
       
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
