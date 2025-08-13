using Contracts.Abstractions.Messages;

namespace Contracts.Services.Statistic
{
    public static class Projection
    {
        public record StatisticSeller(string Id, ushort NumberOrder, ushort NumberMeal, ushort NumberDish, ulong Revenue, long Version) : IProjection
        {
            
        }
    }
}
