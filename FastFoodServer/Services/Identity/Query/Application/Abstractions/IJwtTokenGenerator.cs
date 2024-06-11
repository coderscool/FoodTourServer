using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IJwtTokenGenerator
    {
        Task<string> Generate(string Id, string Role, CancellationToken cancellationToken);
    }
}
