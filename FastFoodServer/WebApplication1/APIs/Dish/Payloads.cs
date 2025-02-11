using Contracts.DataTransferObject;

namespace WebApplication1.APIs.Dish
{
    public class Payloads
    {
        public record CreateDish(Dto.DtoDish Dish, Dto.DtoPrice Price, int Quantity, Dto.DtoSearch Search);
    }
}
