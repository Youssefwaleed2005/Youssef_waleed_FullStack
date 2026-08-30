using FluentValidation;
using Assignment_3.DTOs;
namespace Assignment_3.Validators
{
    public class CreateProductRequestValidator:AbstractValidator<CreatedProductRequest>
    {
        public CreateProductRequestValidator() 
        {
            RuleFor(i => i.Id).NotEmpty().WithMessage("Id cant be empty");

            RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.")
            .Must(x => !x.Contains('<')).WithMessage("Title must not contain HTML tags.");


            RuleFor(p => p.price)
                .NotEmpty().WithMessage("price cant be empty")
                .GreaterThan(0).WithMessage("Price cant be negative")

                

        }
    }
}
