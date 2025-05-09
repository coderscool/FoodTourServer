using FluentValidation;

namespace WebApplication1.APIs.ShoppingCart.Validators
{
    public class AddItemCartPayloadValidator : AbstractValidator<Payloads.AddItemCartPayload>
    {
        public AddItemCartPayloadValidator()
        {
            RuleFor(request => request.RestaurantId)
                .NotEmpty()
                .NotEmpty();
        }
    }
}
