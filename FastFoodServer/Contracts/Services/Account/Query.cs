using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Account
{
    public static class Query
    {
        public class GetAccountId : IQuery
        {
            public string Id { get; set; }
        }
    }
}
