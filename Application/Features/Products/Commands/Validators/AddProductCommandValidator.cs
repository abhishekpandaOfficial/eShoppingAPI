using FluentValidation;

namespace eShopping.API.Application.Features.Products.Commands.Validators;

public class AddProductCommandValidator :AbstractValidator<AddProductCommand>
{
    public AddProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Product name is required.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Product description is required.");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Product price must be greater than 0.");
    }
}