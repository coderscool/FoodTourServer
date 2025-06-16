using Application.Abstractions;
using Application.Services;
using Application.UseCases.Commands;
using ShoppingCart = Contracts.Services.ShoppingCart;
using Contracts.Services.Order;
using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.Events;


namespace Application.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
            => services.AddScoped<IApplicationService, ApplicationService>()
                       .AddScoped<IInteractor<Command.ConfirmOrder>, ConfirmOrderInteractor>()
                       .AddScoped<IInteractor<ShoppingCart.SummaryEvent.CartSubmitted>, PlaceOrderWhenCartSubmittedInteractor>()
                       .AddScoped<IInteractor<DomainEvent.OrderConfirm>, PublishOrderTransportWhenOrderConfirm>();
    }
}
