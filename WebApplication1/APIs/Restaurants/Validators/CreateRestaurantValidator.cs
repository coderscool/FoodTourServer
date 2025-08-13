using FluentValidation;

namespace WebApplication1.APIs.Restaurants.Validators
{
    public class CreateRestaurantValidator : AbstractValidator<Commands.CreateRestaurant>
    {
        public CreateRestaurantValidator()
        {
            RuleFor(request => request.Payload)
                .SetValidator(new CreateRestaurantPayloadValidator())
                .OverridePropertyName(string.Empty);
        }
    }
}
