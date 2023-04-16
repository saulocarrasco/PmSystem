using FluentValidation;
using PmSystem.Domain.Entities;

namespace PmSystem.Domain.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Description)
          .NotEmpty()
          .WithMessage("Description is Required");

            RuleFor(p => p.Price)
         .NotEmpty()
         .WithMessage("Price is Required");

            RuleFor(p => p.Category)
         .NotEmpty()
         .WithMessage("Category is Required");
        }
    }
}
