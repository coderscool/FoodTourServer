using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataTransferObject.Validators
{
    public class SearchValidator : AbstractValidator<Dto.DtoSearch>
    {
        public SearchValidator() 
        {
            RuleFor(search => search.Category)
                .NotNull()
                .NotEmpty();
        }
    }
}
