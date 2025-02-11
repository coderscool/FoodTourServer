using FluentValidation;

namespace WebApplication1.APIs.Identities.Validators
{
    public class ListRestaurantItemsValidator : AbstractValidator<Queries.ListRestaurantItems>
    {
        public ListRestaurantItemsValidator() 
        {
            RuleFor(request => request.Offset)
                .NotNull()
                .NotEmpty();

            RuleFor(request => request.Limit)
                .NotNull()
                .NotEmpty();
        }
    }
}
