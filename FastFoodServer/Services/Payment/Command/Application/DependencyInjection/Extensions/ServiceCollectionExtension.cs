using Application.Abstractions;
using Application.Services;
using Order = Contracts.Services.Order;
using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.Events;
using Contracts.Services.Payment;
using Application.UseCases.Commands;

namespace Application.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
            => services.AddScoped<IApplicationService, ApplicationService>()
                       .AddScoped<IInteractor<Order.SummaryEvent.OrderTransport>, RequestPaymentWhenOrderTransportInteractor>()
                       .AddScoped<IInteractor<Command.CompletePayment>, CompletePaymentInteractor>()
                       .AddScoped<IInteractor<Command.SellerConfirmPayment>, SellerConfirmPaymentInteractor>();
    }
}
