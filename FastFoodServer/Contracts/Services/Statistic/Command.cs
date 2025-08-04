using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Statistic
{
    public static class Command
    {
        public record CreateSellerStatistic(string Id) : Message, ICommand;
        public record UpdateNumberDish(string Id) : Message, ICommand;
        public record UpdateRevanue(string Id, int Quantity, long Price) : Message, ICommand;
    }
}
