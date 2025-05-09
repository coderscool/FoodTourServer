using Contracts.DataTransferObject.Validators;
using FluentValidation;

namespace WebApplication1.APIs.ShoppingCart.Validators
{
    public class CreateCartPayloadValidator : AbstractValidator<Payloads.CreateCartPayload>
    {
        public CreateCartPayloadValidator()
        {
            RuleFor(request => request.Customer)
                .SetValidator(new PersonValidator())
                .OverridePropertyName(string.Empty);

            RuleFor(request => request.Description)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
