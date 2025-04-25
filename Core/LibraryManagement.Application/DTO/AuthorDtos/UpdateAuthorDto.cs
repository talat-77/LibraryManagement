using LibraryManagement.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManagement.Application.DTO.AuthorDtos
{
    public class UpdateAuthorDto
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }
    }
}
