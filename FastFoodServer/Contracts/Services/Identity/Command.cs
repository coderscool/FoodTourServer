using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;

namespace Contracts.Services.Identity
{
    public static class Command
    {
        public record RegisterUser(string UserName, string PassWord, string Name, string Image, string Role) : Message, ICommand;
        public record RegisterSeller(string UserName, string PassWord, Dto.DtoPerson Seller, string Image, string Nation, 
            Dto.TimeActive TimeActive, string Role): Message, ICommand;
        public record RegisterShipper(string UserName, string PassWord, Dto.DtoPerson Shipper, string Image, string Role) : Message, ICommand;
    }
}
