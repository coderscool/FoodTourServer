using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Payment
{
    public static class Command
    {
        public record RequestPayment(string Id, string OrderId, ulong Total) : Message, ICommand;

        public record RefundPayment(string Id, Dto.DtoPrice Price, uint Quantity) : Message, ICommand;

        public record CreatePayment(string Id) : Message, ICommand;
    }
}
