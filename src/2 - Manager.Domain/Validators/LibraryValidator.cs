using Manager.Domain.Entities;
using FluentValidation;

namespace Manager.Domain.Validators
{
    public class LibraryValidator : AbstractValidator<Library>
    {
        public LibraryValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("");

            RuleFor(x => x.BookName)
                .NotNull()
                .WithMessage("Nenhum Name Book"); 

            RuleFor(x => x.BookCodeSerial)
                .NotNull()
                .WithMessage("Nenhum Code Serial");      
        }
    }
}