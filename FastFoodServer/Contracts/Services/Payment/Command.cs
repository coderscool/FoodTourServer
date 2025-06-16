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
        public record RequestPayment(string OrderId, Dto.DtoPrice Price, ushort Quantity, string PaymentMethod) : Message, ICommand;

        public record RefundPayment(string Id, Dto.DtoPrice Price, uint Quantity) : Message, ICommand;

        public record CreatePayment(string Id) : Message, ICommand;
    }
}
