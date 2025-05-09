using FluentValidation;

namespace WebApplication1.APIs.ShoppingCart.Validators
{
    public class ChangeDescriptionCartValidator : AbstractValidator<Commands.ChangeDescriptionCart>
    {
        public ChangeDescriptionCartValidator()
        {
            RuleFor(request => request.Id)
                .NotNull()
                .NotEmpty();

            RuleFor(request => request.Description)
               .NotNull()
               .NotEmpty();
        }
    }
}
