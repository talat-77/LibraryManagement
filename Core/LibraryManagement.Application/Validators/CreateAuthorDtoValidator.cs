using FluentValidation;
using LibraryManagement.Application.DTO.AuthorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Validators
{
    public class CreateAuthorDtoValidator : AbstractValidator<CreateAuthorDto>
    {
        public CreateAuthorDtoValidator() {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad boş olamaz.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Doğum tarihi boş olamaz.")
                .LessThan(DateTime.Now).WithMessage("Doğum tarihi gelecekte olamaz.");

        }
    }
}
