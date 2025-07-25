using Contracts.Services.Delivery;
using FluentValidation;

namespace WebApplication1.APIs.Delivery.Validators
{
    public class RequireDishDeliveryValidator : AbstractValidator<Commands.RequireDishDelivery>
    {
    }
}
