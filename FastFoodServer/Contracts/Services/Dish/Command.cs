using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;

namespace Contracts.Services.Dish
{
    public static class Command
    {
        public record CreateDish(string RestaurantId, Dto.DtoDish Dish, List<Dto.ExtraFood> Extra, Dto.DtoPrice Price, ushort Quantity, Dto.DtoSearch Search) : Message, ICommand;
        public record UpdateQuantity(string Id, uint Quantity) : Message, ICommand;
        public record UpdatePriceDish(string Id, Dto.DtoPrice Price) : Message, ICommand;
    }
}
