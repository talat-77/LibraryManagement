using LibraryManagement.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities
{
    public class Book : BaseEntity
    {
        
        public string Title { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

    }
}
