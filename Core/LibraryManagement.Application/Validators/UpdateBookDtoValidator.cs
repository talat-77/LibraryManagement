using FluentValidation;
using LibraryManagement.Application.DTO.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Validators
{
    public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookDtoValidator()
        {
            RuleFor(x=>x.Title)
                .NotEmpty().WithMessage("Kitap başlığı boş olamaz.")
            .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");
            RuleFor(x => x.PublishedYear)
            .GreaterThan(0).WithMessage("Yayın yılı 0'dan büyük olmalıdır.")
            .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("Yayın yılı bugünden büyük olamaz.");
            RuleFor(x => x.AuthorId)
            .GreaterThan(0).WithMessage("Geçerli bir yazar ID'si belirtilmelidir.");
        }
    }
}
