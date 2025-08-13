using Contracts.DataTransferObject;

namespace WebApplication1.APIs.ShoppingCart
{
    public static class Payloads
    {
        public record AddItemCartPayload(string RestaurantId, string DishId, List<string> Extra, Dto.DtoDish Dish, Dto.DtoPrice Price, ushort Quantity, string Note);

        public record CheckOutCartPayload(List<string> ChooseId, Dto.DtoPerson Customer, ulong Total, string PaymentMethod);

    }
}
