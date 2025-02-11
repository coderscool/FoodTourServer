using Contracts.DataTransferObject;

namespace WebApplication1.APIs.Restaurants
{
    public class Payloads
    {
        public record CreateRestaurant(Dto.DtoPerson Restaurant, Dto.DtoSearch Search);
    }
}
