using FluentValidation;

namespace WebApplication1.APIs.ShoppingCart.Validators
{
    public class ChangeCustomerCartValidator :AbstractValidator<Commands.ChangeCustomerCart>
    {
        public ChangeCustomerCartValidator()
        {
            RuleFor(request => request.Id)
                .NotNull()
                .NotEmpty();

            RuleFor(request => request.Customer)
               .NotNull()
               .NotEmpty();
        }
    }
}
