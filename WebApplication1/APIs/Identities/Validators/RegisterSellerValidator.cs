using FluentValidation;

namespace WebApplication1.APIs.Identities.Validators
{
    public class RegisterSellerValidator : AbstractValidator<Commands.RegisterSeller>
    {
        public RegisterSellerValidator()
        {
        }
    }
}
