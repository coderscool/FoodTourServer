using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;

namespace Contracts.Services.Dish
{
    public static class DomainEvent
    {
        public record DishCreate(string Id, string RestaurantId, Dto.DtoDish Dish, List<Dto.ExtraFood> Extra, Dto.DtoPrice Price, ushort Quantity, Dto.DtoSearch Search, long Version) : Message, IDomainEvent;
        public record QuantityUpdate(string Id, int Quantity, long Version) : Message, IDomainEvent;
        public record DishUpdatePrice(string Id, Dto.DtoPrice Price, long Version) : Message, IDomainEvent;
    }
}
