using Contracts.DataTransferObject;

namespace WebApplication1.APIs.Identities
{
    public class Payloads
    {
        public record SignUp(string UserName, string PassWord, Dto.DtoPerson Person, string Role);
    }
}
