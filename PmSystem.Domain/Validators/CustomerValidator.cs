using FluentValidation;
using PmSystem.Domain.Entities;

namespace PmSystem.Domain.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.Name)
             .NotEmpty()
             .WithMessage("Name is Required");

            RuleFor(p => p.Phone)
           .NotEmpty()
           .WithMessage("Phone is Required");

            RuleFor(p => p.Email)
          .NotEmpty()
          .WithMessage("Email is Required");
        }
    }
}
