using Contracts.DataTransferObject.Validators;
using FluentValidation;

namespace WebApplication1.APIs.Restaurants.Validators
{
    public class CreateRestaurantPayloadValidator : AbstractValidator<Payloads.CreateRestaurant>
    {
        public CreateRestaurantPayloadValidator()
        {
            RuleFor(request => request.Restaurant)
                .SetValidator(new PersonValidator())
                .OverridePropertyName(string.Empty);

            RuleFor(request => request.Search)
                .SetValidator(new SearchValidator())
                .OverridePropertyName(string.Empty);
        }
    }
}
