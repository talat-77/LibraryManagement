using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.DTO.BookDtos
{
    public class ResultBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
