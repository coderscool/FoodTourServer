using Contracts.Services.Identity;
using FluentValidation;

namespace WebApi.Controllers.Identity.Validation
{
    public class RegisterUserValidation : AbstractValidator<Command.Register>
    {
        public RegisterUserValidation()
        {
            RuleFor(p => p.PassWord).MinimumLength(6).MaximumLength(30);
        }

    }
}
