using FluentValidation;

namespace WebApplication1.APIs.Identities.Validators
{
    public class RegisterUserValidator : AbstractValidator<Commands.RegisterUser>
    {
        public RegisterUserValidator()
        {
            RuleFor(request => request.Payload)
                .SetValidator(new SignUpPayloadValidator())
                .OverridePropertyName(string.Empty);
        }
    }
}
