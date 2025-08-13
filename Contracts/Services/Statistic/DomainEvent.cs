using Contracts.Abstractions.Messages;

namespace Contracts.Services.Statistic
{
    public static class DomainEvent
    {
        public record StatisticSellerCreate(string Id, ushort NumberOrder, ushort NumberMeal, ushort NumberDish, ulong Revenue, long Version) : Message, IDomainEvent;
        public record NumberDishUpdate(string Id, int Quantity, long Version) : Message, IDomainEvent;
        public record RevenueUpdate(string Id, ulong Revanue, long Version) : Message, IDomainEvent;
        public record NumberOrderUpdate(string Id, ushort NumberOrder, long Version) : Message, IDomainEvent;
    }
}
