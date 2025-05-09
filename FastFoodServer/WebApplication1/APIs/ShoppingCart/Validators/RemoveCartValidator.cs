using FluentValidation;

namespace WebApplication1.APIs.ShoppingCart.Validators
{
    public class RemoveCartValidator : AbstractValidator<Commands.RemoveCart>
    {
        public RemoveCartValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}
