using Application.Abstractions;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Identity = Contracts.Services.Identity;
using Application.UseCases.Events;
using Dish = Contracts.Services.Dish;
using Order = Contracts.Services.Order;
using Payment = Contracts.Services.Payment;

namespace Application.DepedencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
            => services.AddScoped<IApplicationService, ApplicationService>()
                       .AddScoped<IInteractor<Identity.DomainEvent.SellerRegister>, CreateStatisticWhenRegisterSellerInteractor>()
                       .AddScoped<IInteractor<Dish.DomainEvent.DishCreate>, UpdateNumberDishWhenDishCreateInteractor>()
                       .AddScoped<IInteractor<Order.SummaryEvent.OrderTransport>, UpdateNumberOrderWhenOrderTransportInteractor>()
                       .AddScoped<IInteractor<Payment.DomainEvent.PaymentSellerConnfirm>, UpdateRevanueWhenPaymentSellerConfirmInteractor>();
    }
}
