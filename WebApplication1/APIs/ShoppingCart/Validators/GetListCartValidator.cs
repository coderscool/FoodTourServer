using FluentValidation;

namespace WebApplication1.APIs.ShoppingCart.Validators
{
    public class GetListCartValidator : AbstractValidator<Queries.GetListCart>
    {
        public GetListCartValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("CartId is required.")
                .MaximumLength(50).WithMessage("CartId must not exceed 50 characters.");
        }
    }
}
