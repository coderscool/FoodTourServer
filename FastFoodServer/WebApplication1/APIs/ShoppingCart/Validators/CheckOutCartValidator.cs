using FluentValidation;

namespace WebApplication1.APIs.ShoppingCart.Validators
{
    public class CheckOutCartValidator : AbstractValidator<Commands.CheckOutCart>
    {
        public CheckOutCartValidator()
        {
            RuleFor(x => x.Payload.ChooseId).NotEmpty().WithMessage("ChooseId cannot be empty.");
            RuleFor(x => x.Payload.Customer).NotNull().WithMessage("Customer cannot be null.");
            RuleFor(x => x.Payload.PaymentMethod).NotEmpty().WithMessage("Payment method cannot be empty.");
        }
    }
}
