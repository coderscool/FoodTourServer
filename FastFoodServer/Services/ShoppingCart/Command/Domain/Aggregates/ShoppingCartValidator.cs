using FluentValidation;

namespace Domain.Aggregates
{
    public class ShoppingCartValidator : AbstractValidator<ShoppingCart>
    {
        public ShoppingCartValidator()
        {
            RuleFor(cart => cart.Id)
                .NotEmpty();
        }
    }
}
