using Application.Abstractions;
using Application.Services;
using Application.UseCases.Commands;
using ShoppingCart = Contracts.Services.ShoppingCart;
using Delivery = Contracts.Services.Delivery;
using Contracts.Services.Order;
using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.Events;


namespace Application.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
            => services.AddScoped<IApplicationService, ApplicationService>()
                       .AddScoped<IInteractor<Command.ConfirmRequireOrder>, ConfirmRequireOrderInteractor>()
                       .AddScoped<IInteractor<ShoppingCart.SummaryEvent.CartSubmitted>, PlaceOrderWhenCartSubmittedInteractor>()
                       .AddScoped<IInteractor<Command.CompleteDishOrder>, CompleteDishOrderInteractor>()
                       .AddScoped<IInteractor<Command.ConfirmOrder>, ConfirmOrderInteractor>()
                       .AddScoped<IInteractor<Delivery.DomainEvent.DeliveryRequireDish>, RequireOrderWhenDeiveryRequireDishInteractor>()   
                       .AddScoped<IInteractor<DomainEvent.OrderConfirm>, PublishOrderTransportWhenOrderConfirmInteractor>();
    }
}
