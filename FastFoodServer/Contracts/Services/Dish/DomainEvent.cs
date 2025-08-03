using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;

namespace Contracts.Services.Dish
{
    public static class DomainEvent
    {
        public record DishCreate(string Id, string RestaurantId, Dto.DtoDish Dish, List<Dto.ExtraFood> Extra, Dto.DtoPrice Price, ushort Quantity, Dto.DtoSearch Search, long Version) : Message, IDomainEvent;
        public record DishQuantityUpdate(string Id, ushort Quantity, long Version) : Message, IDomainEvent;
        public record DishUpdate(string Id, Dto.DtoDish Dish, List<Dto.ExtraFood> Extra, Dto.DtoPrice Price, long Version) : Message, IDomainEvent;
        public record DishHidden(string Id, bool Hidden, long Version) : Message, IDomainEvent;
    }
}
