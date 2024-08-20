using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Identity
{
    public static class Command
    {
        public record Register(string UserName, string PassWord, Dto.Person Person, Dto.Search Search, string Image, string Role): Message, ICommand;
    }
}
