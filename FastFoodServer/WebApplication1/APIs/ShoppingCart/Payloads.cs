using Contracts.DataTransferObject;

namespace WebApplication1.APIs.ShoppingCart
{
    public static class Payloads
    {
        public record AddItemCartPayload(string RestaurantId, string DishId, Dto.DtoPerson Restaurant, Dto.DtoDish Dish, Dto.DtoPrice Price, ushort Quantity, string Note);

    }
}
