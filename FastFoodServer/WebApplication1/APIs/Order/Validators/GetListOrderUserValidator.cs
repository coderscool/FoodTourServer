using FluentValidation;

namespace WebApplication1.APIs.Order.Validators
{
    public class GetListOrderUserValidator : AbstractValidator<Queries.GetListOrderUser>
    {
        public GetListOrderUserValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.Limit).GreaterThan(0).WithMessage("Limit must be greater than 0.");
            RuleFor(x => x.Offset).GreaterThanOrEqualTo(0).WithMessage("Offset must be greater than or equal to 0.");
        }
    }
}
