using FluentValidation;

namespace WebApplication1.APIs.Dish.Validators
{
    public class CreateDishPayloadValidator : AbstractValidator<Payloads.CreateDish>
    {
        public CreateDishPayloadValidator()
        {
            RuleFor(request => request.Dish.Name)
                .NotNull();

            RuleFor(request => request.Dish.Image)
                .NotNull();
        }
    }
}
