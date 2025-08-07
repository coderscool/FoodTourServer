using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataTransferObject.Validators
{
    public class PersonValidator : AbstractValidator<Dto.DtoPerson>
    {
        public PersonValidator() 
        {
            RuleFor(person => person.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(person => person.Address)
                .NotNull()
                .NotEmpty();

            RuleFor(person => person.Phone)
                .NotNull()
                .NotEmpty();
        }
    }
}
