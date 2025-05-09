using FluentValidation;

namespace WebApplication1.APIs.ShoppingCart.Validators
{
    public class CreateCartValidator : AbstractValidator<Commands.CreateCart>
    {
        public CreateCartValidator()
        {
            RuleFor(request => request.Payload)
                .SetValidator(new CreateCartPayloadValidator())
                .OverridePropertyName(string.Empty);
        }
    }
}
