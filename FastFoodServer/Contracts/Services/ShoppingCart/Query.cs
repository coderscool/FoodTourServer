using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.ShoppingCart
{
    public static class Query
    {
        public class CustomerCartQuery : IQuery
        {
            public string CustomerId { get; set; }
        }
    }
}
