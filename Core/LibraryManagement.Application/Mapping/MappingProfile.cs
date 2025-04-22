using AutoMapper;
using LibraryManagement.Application.DTO.AuthorDtos;
using LibraryManagement.Application.DTO.BookDtos;
using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          CreateMap<CreateAuthorDto,Author>().ReverseMap();
            CreateMap<ResultAuthorDto, Author>().ReverseMap();
            CreateMap<UpdateAuthorDto, Author>().ReverseMap();
            
            CreateMap<CreateBookDto, Book>().ReverseMap();  
            CreateMap<ResultBookDto, Book>().ReverseMap();  
            CreateMap<UpdateBookDto, Book>().ReverseMap();
        }
    }
}
