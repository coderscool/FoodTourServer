using FluentValidation;

namespace WebApplication1.APIs.ShoppingCart.Validators
{
    public class ChangedPaymentCartValidator : AbstractValidator<Commands.ChangedPaymentCart>
    {
        public ChangedPaymentCartValidator()
        {

        }
    }
}
