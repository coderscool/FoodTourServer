using FluentValidation;

namespace WebApplication1.APIs.Identities.Validators
{
    public class SignInValidator : AbstractValidator<Queries.SignIn>
    {
        public SignInValidator()
        {
            RuleFor(request => request.Username)
                .NotNull()
                .NotEmpty();

            RuleFor(request => request.Password)
                .NotNull()
                .NotEmpty();
        }
    }
}
