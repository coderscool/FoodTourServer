using FluentValidation;

namespace WebApplication1.APIs.ShoppingCart.Validators
{
    public class AddItemCartValidator : AbstractValidator<Commands.AddCartItem>
    {
        public AddItemCartValidator()
        {
            RuleFor(request => request.Payload)
                .SetValidator(new AddItemCartPayloadValidator())
                .OverridePropertyName(string.Empty);

            RuleFor(request => request.CartId)
                .NotEmpty()
                .NotNull();
        }
    }
}
