using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;

namespace Contracts.Services.Order
{
    public class Command
    {
        public record ConfirmOrder(string OrderId, string ItemId, Dto.DtoPerson Restaurant, bool Confirm) : Message, ICommand;
        public record CancelOrder(string OrderId, string ItemId) : Message, ICommand;
        public record CompleteDishOrder(string OrderId, string ItemId) : Message, ICommand;
        public record RequireOrder(string OrderId, string ItemId) : Message, ICommand;
        public record ConfirmRequireOrder(string OrderId, string ItemId, bool Confirm) : Message, ICommand;
        public record RequireCompleteOrder(string OrderId, string ItemId) : Message, ICommand;
        public record CompleteOrder(string OrderId, string ItemId, bool Confirm) : Message, ICommand;
        public record PlaceOrder(string CustomerId, Dto.DtoPerson Customer, ulong Total, string PaymentMethod, IEnumerable<Dto.CartItem> Items) : Message, ICommand;
    }
}
