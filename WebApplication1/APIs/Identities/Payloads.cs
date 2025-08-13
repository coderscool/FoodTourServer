using Contracts.DataTransferObject;

namespace WebApplication1.APIs.Identities
{
    public class Payloads
    {
        public record SignUpUser(string UserName, string PassWord, string Name, string Image, string Role);
        public record SignUpSeller(string UserName, string PassWord, Dto.DtoPerson Seller, string Image, string Nation,
            Dto.TimeActive TimeActive, string Role);
        public record SignUpShipper(string UserName, string PassWord, Dto.DtoPerson Shipper, string Image, string Role);

    }
}
