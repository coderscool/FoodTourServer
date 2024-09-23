using Application.Abstractions;
using Contracts.Services.Account;
using Grpc.Core;
using GrpcService1;

namespace GrpcService1.Services
{
    public class AccounterService : Accounter.AccounterBase
    {
        private readonly ILogger<AccounterService> _logger;
        private readonly IInteractor<Query.GetAccountId, Projection.Account> _getAccountInteractor;
        public AccounterService(ILogger<AccounterService> logger,
            IInteractor<Query.GetAccountId, Projection.Account> getAccountInteractor)
        {
            _logger = logger;
            _getAccountInteractor = getAccountInteractor;
        }

        public override async Task<AccountReply> GetBudgetAccount(AccountRequest request, ServerCallContext context)
        {
            var query = new Query.GetAccountId
            {
                Id = request.Id
            };
            var result = await _getAccountInteractor.InteractAsync(query, context.CancellationToken);
            if(request == null)
            {
                return null;
            }
            return await Task.FromResult(new AccountReply
            {
                Id = request.Id,
                Budget = result.Budget
            });
        }
    }
}