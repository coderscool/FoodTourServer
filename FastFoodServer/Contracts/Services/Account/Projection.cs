using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Account
{
    public static class Projection 
    {
        public class Account : IProjection
        {
            public string Id { get; set; }
            public long Budget { get; set; }
        }
    }
}
