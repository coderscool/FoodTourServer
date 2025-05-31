using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Abstractions.Paging
{
    [ExcludeFromTopology]
    public interface IFindResult<out TProjection>
    {
        IReadOnlyList<TProjection> Items { get; }
    }
}
