namespace WebApplication1.APIs.Account
{
    public class Payloads
    {
        public record StoreNearsQuery(int Limit, int Offset, double Latitude, double Longitude);
    }
}
