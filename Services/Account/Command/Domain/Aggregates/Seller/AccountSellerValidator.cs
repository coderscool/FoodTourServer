using FluentValidation;

namespace Domain.Aggregates.Seller
{
    public class AccountSellerValidator : AbstractValidator<AccountSeller>
    {
        public AccountSellerValidator() 
        {
            RuleFor(account => account.Id)
                .NotEmpty();
        }
    }
}
