using FluentValidation;

namespace Domain.Aggregates
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(cart => cart.Id)
                .NotEmpty();
        }
    }
}
