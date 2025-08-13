using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Entities
{
    public abstract class Entity<TValidator> : IEntity
    where TValidator : IValidator, new()
    {
        public string Id { get; protected set; }
        public bool IsDeleted { get; protected set; }

        protected void Validate()
            => new TValidator()
                .Validate(ValidationContext<IEntity>
                    .CreateWithOptions(this, strategy
                        => strategy.ThrowOnFailures()));
    }
}
