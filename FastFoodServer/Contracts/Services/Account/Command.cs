using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Account
{
    public static class Command
    {
        public record RequestPayment(string Id, string OrderId, long Price, int Quantity) : Message, ICommand;

        public record CreateAccount(string Id) : Message, ICommand;

        public record RefundPayment(string Id, string OrderId, long Price, int Quantity) : Message, ICommand;
    }
}
