using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Identity
{
    public static class Command
    {
        public record RegisterUser(Guid Id, string UserName, string PassWord, string ConfirmPassWord, string Name, string Image);
    }
}
