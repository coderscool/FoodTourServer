using FluentValidation;

namespace WebApplication1.APIs.Identities.Validators
{
    public class SignUpPayloadValidator : AbstractValidator<Payloads.SignUpUser>
    {
        public SignUpPayloadValidator()
        {
            RuleFor(request => request.UserName)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(30);

            RuleFor(request => request.PassWord)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(16)
                .Matches("[A-Z]").WithMessage("Password must contain 1 uppercase letter")
                .Matches("[a-z]").WithMessage("Password must contain 1 lowercase letter")
                .Matches("[0-9]").WithMessage("Password must contain 1 number")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain 1 non alphanumeric");
        }
    }
}
