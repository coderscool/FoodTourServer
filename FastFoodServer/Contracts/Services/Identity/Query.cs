using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;
using Contracts.Services.Identity.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Identity
{
    public static class Query
    {
        public record Login(string Username, string Password) : IQuery
        {
            public static implicit operator Login(LoginRequest request)
                => new(request.UserName, request.PassWord);
        }

        public record ListRestaurantItems(Paging Paging) : IQuery
        {
            public static implicit operator ListRestaurantItems(ListRestaurantItemsRequest request)
                => new(request.Paging);
        }
    }
}
