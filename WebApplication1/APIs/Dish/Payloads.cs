using Contracts.DataTransferObject;

namespace WebApplication1.APIs.Dish
{
    public class Payloads
    {
        public record CreateDish(Dto.DtoDish Dish, List<Dto.ExtraFood> Extra, Dto.DtoPrice Price, ushort Quantity, Dto.DtoSearch Search);
    }
}
