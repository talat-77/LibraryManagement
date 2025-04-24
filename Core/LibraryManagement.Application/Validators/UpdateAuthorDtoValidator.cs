using FluentValidation;
using LibraryManagement.Application.DTO.AuthorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Validators
{
    public class UpdateAuthorDtoValidator : AbstractValidator<UpdateAuthorDto>
    {
        public UpdateAuthorDtoValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Ad boş olamaz.")
               .Length(2, 100).WithMessage("Yazaar ismi 2 ile 100 kelime arasında olmalı");
            RuleFor(x => x.BirthDate)
               .NotEmpty().WithMessage("Doğum tarihi boş olamaz.")
               .LessThan(DateTime.Now).WithMessage("Doğum tarihi gelecekte olamaz.");
               

        }
    }
}
