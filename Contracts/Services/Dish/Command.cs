using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;

namespace Contracts.Services.Dish
{
    public static class Command
    {
        public record CreateDish(string RestaurantId, Dto.DtoDish Dish, List<Dto.ExtraFood> Extra, Dto.DtoPrice Price, ushort Quantity, Dto.DtoSearch Search) : Message, ICommand;
        public record UpdateQuantityDish(string Id, ushort Quantity) : Message, ICommand;
        public record UpdateDish(string Id, Dto.DtoDish Dish, List<Dto.ExtraFood> Extra, Dto.DtoPrice Price) : Message, ICommand;
        public record HiddenDish(string Id, bool Hidden) : Message, ICommand;

    }
}
