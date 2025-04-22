using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.DTO.BookDtos
{
    public class CreateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public int AuthorId { get; set; }
        public decimal Price { get; set; }
    }
}
