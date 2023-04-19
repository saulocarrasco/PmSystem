using FluentValidation;
using PmSystem.Domain.Dtos;
using PmSystem.Domain.Entities;

namespace PmSystem.Domain.Validators
{
    public class CustomerItemValidator : AbstractValidator<CustomerItemDto>
    {
        public CustomerItemValidator()
        {
            RuleFor(p => p.Quantity)
             .NotEmpty()
             .WithMessage("Quantity is Required");

            RuleFor(p => p.ProductId)
           .NotEmpty()
           .WithMessage("Product is Required");

            RuleFor(p => p.CustomerId)
          .NotEmpty()
          .WithMessage("Customer is Required");
        }
    }
}
