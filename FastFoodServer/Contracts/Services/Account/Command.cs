using Contracts.DataTransferObject;
using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Account
{
    public static class Command
    {
        public record CreateAccountUser(string Id, string Name, string Image) : Message, ICommand;
        public record CreateAccountSeller(string Id, Dto.DtoPerson Seller, string Image, string Nation, Dto.TimeActive TimeActive) : Message, ICommand;
        public record CreateAccountShipper(string Id, Dto.DtoPerson Shipper, string Image) : Message, ICommand;
        public record ChangedAccount(string Id, Dto.DtoPerson Person) : Message, ICommand;
    }
}
