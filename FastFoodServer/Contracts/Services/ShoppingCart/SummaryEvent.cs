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
        public record CartSubmitted(Dto.DtoShoppingCart Cart, long Version) : Message, ISummaryEvent;
    }
}
