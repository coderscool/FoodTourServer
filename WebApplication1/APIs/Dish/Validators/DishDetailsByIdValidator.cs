using FluentValidation;

namespace WebApplication1.APIs.Dish.Validators
{
    public class DishDetailsByIdValidator : AbstractValidator<Queries.DishDetailsById>
    {
        public DishDetailsByIdValidator() 
        {
            RuleFor(request => request.Id)
                .NotNull();
        }
    }
}
