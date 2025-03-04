using Application.Abstractions;
using Contracts.Services.Account;
using Grpc.Core;
using GrpcService1;

namespace GrpcService1.Services
{
    public class AccounterService : Accounter.AccounterBase
    {
        private readonly ILogger<AccounterService> _logger;
        public AccounterService(ILogger<AccounterService> logger)
        {
            _logger = logger;
        }

    }
}