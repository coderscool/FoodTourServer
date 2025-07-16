using Contracts.Abstractions.Messages;
using Contracts.Services.Cart.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.ShoppingCart
{
    public static class Query
    {
        public record CustomerCartQuery(string CustomerId) : IQuery
        {
            public static implicit operator CustomerCartQuery(GetListCartRequest request)
                => new CustomerCartQuery(request.CustomerId);
        }
    }
}
