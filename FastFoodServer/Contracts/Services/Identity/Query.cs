using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Identity
{
    public static class Query
    {
        public class Login : IQuery
        {
            public string UserName { get; set; } = string.Empty;
            public string PassWord { get; set; } = string.Empty;
        }
    }
}
