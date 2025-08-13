using FluentValidation;

namespace WebApplication1.APIs.Account.Validators
{
    public class GetListStoreNearsValidator : AbstractValidator<Queries.GetListStoreNears>
    {
        public GetListStoreNearsValidator()
        {
            RuleFor(request => request.Latitude)
                .NotNull()
                .NotEmpty();

            RuleFor(request => request.Longitude)
                .NotNull()
                .NotEmpty();

        }
    }
}
