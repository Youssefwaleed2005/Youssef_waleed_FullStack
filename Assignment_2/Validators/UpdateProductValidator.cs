using FluentValidation;
using Assignment_3.DTOs;

namespace Assignment_3.Validators
{
    public class UpdateProductValidator:AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductValidator() 
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title cant be empty")
                .MaximumLength(200).WithMessage("Title cant exceed 200 characters")
                .Must(x => !x.Contains('<')).WithMessage("Title cant have HTML Tags");

            RuleFor(p => p.Price)
               .NotEmpty().WithMessage("Price cant be empty");

        }
    }
}
