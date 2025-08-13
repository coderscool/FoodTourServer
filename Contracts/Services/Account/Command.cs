using Contracts.DataTransferObject;
using Contracts.Abstractions.Messages;

namespace Contracts.Services.Account
{
    public static class Command
    {
        public record CreateAccountUser(string Id, string Name, string Image) : Message, ICommand;
        public record CreateAccountSeller(string Id, Dto.DtoPerson Seller, string Image, string Nation, Dto.TimeActive TimeActive) : Message, ICommand;
        public record CreateAccountShipper(string Id, Dto.DtoPerson Shipper, string Image) : Message, ICommand;
    }
}
