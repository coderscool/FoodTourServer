using Contracts.Abstractions.Messages;
using Contracts.Services.Statistic.Protobuf;

namespace Contracts.Services.Statistic
{
    public static class Projection
    {
        public record StatisticSeller(string Id, ushort NumberOrder, ushort NumberMeal, ushort NumberDish, ulong Revenue, long Version) : IProjection
        {
            public static implicit operator StatisticDetail(StatisticSeller projection)
            {
                return new ()
                {
                    Id = projection.Id,
                    NumberOrder = projection.NumberOrder,
                    NumberMeal = projection.NumberMeal,
                    NumberDish = projection.NumberDish,
                    Revenue = projection.Revenue
                };
            }
        }
    }
}
