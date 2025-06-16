using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Entities
{
    public interface IEntity
    {
        string Id { get; }
        bool IsDeleted { get; }
    }
}
