using FluentValidation;

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
