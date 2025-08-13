using Contracts.Abstractions.Messages;

namespace Contracts.Services.Statistic
{
    public static class Command
    {
        public record CreateSellerStatistic(string Id) : Message, ICommand;
        public record UpdateNumberDish(string Id) : Message, ICommand;
        public record UpdateRevanue(string Id, ulong Revanue) : Message, ICommand;
        public record UpdateNumberOrder(string Id, ushort NumberOrder) : Message, ICommand;
    }
}
