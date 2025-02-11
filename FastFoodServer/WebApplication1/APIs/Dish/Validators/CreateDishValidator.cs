using FluentValidation;

namespace WebApplication1.APIs.Dish.Validators
{
    public class CreateDishValidator : AbstractValidator<Commands.CreateDish>
    {
        public CreateDishValidator() 
        {
            RuleFor(request => request.RestaurantId)
                .NotNull()
                .NotEmpty();

            RuleFor(request => request.Payload)
                .SetValidator(new CreateDishPayloadValidator())
                .OverridePropertyName(string.Empty);
        }
    }
}
