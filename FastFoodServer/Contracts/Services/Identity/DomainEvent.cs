using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Identity
{
    public static class DomainEvent
    {
        public record UserRegister(string Id, string UserName, string PassWord, string Name, string Image, string Role, long Version) : Message, IDomainEvent;
        public record SellerRegister(string Id, string UserName, string PassWord, Dto.DtoPerson Seller, string Image, string Nation,
            Dto.TimeActive TimeActive, string Role, long Version) : Message, IDomainEvent;
        public record ShipperRegister(string Id, string UserName, string PassWord, Dto.DtoPerson Shipper, string Image, string Role, long Version) : Message, IDomainEvent;
    }
}
