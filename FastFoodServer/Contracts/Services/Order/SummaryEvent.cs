using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Order
{
    public static class SummaryEvent
    {
        public record OrderTransport(Dto.DtoOrder Order, long Version) : Message, ISummaryEvent;
    }
}
