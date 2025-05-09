using Contracts.DataTransferObject;

namespace WebApplication1.APIs.ShoppingCart
{
    public static class Payloads
    {
        public record CreateCartPayload(string CustomerId, Dto.DtoPerson Customer, string Description);
        public record AddItemCartPayload(string RestaurantId, string DishId, Dto.DtoPerson Restaurant, Dto.DtoDish Dish, Dto.DtoPrice Price, ushort Quantity, string Note);

    }
}
