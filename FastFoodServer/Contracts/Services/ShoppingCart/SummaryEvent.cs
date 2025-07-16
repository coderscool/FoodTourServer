using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.ShoppingCart
{
    public static class SummaryEvent
    {
        public record CartSubmitted(Dto.DtoShoppingCart Cart, Dto.DtoPerson Customer, ulong Total, string PaymentMethod, long Version) : Message, ISummaryEvent;
    }
}
