using Contracts.Services.Order;
using MassTransit;
using WebApplication1.Abstractions;
using WebApplication1.APIs.Order.Validators;

namespace WebApplication1.APIs.Order
{
    public static class Commands
    {
        public record ConfirmOrder(IBus Bus,string OrderId, Payloads.ConfirmOrderPayload Payload, CancellationToken CancellationToken)
            : Validatable<ConfirmOrderVaalidator>, ICommand<Command.ConfirmOrder>
        {
            public Command.ConfirmOrder Command
                => new(OrderId, Payload.ItemId, Payload.Restaurant, Payload.Confirm);
        }

        public record CompleteDishOrder(IBus Bus, string OrderId, string ItemId, CancellationToken CancellationToken)
            : Validatable<CompleteDishOrderValidator>, ICommand<Command.CompleteDishOrder>
        {
            public Command.CompleteDishOrder Command
                => new(OrderId, ItemId);
        }

        public record ConfirmRequireOrder(IBus Bus, string OrderId, string ItemId, bool Confirm, CancellationToken CancellationToken)
            : Validatable<ConfirmRequireOrderValidator>, ICommand<Command.ConfirmRequireOrder>
        {
            public Command.ConfirmRequireOrder Command
                => new(OrderId, ItemId, Confirm);
        }
    }
}
