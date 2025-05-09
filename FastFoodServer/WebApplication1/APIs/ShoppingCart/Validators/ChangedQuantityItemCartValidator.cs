using FluentValidation;

namespace WebApplication1.APIs.ShoppingCart.Validators
{
    public class ChangedQuantityItemCartValidator : AbstractValidator<Commands.ChangedQuantityItemCart>
    {
        public ChangedQuantityItemCartValidator()
        {
            RuleFor(request => request.CartId)
                .NotNull()
                .NotEmpty();

            RuleFor(request => request.ItemId)
                .NotNull()
                .NotEmpty();

            RuleFor(request => request.Quantity)
                .NotNull()
                .NotEmpty();
        }
    }
}
