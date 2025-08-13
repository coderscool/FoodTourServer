using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.User
{
    public class AccountUserValidator : AbstractValidator<AccountUser>
    {
        public AccountUserValidator()
        {
            RuleFor(account => account.Id)
                .NotEmpty();
        }
    }
}
