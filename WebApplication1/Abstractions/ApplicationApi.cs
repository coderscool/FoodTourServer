using Contracts.Abstractions.Messages;
using NoContent = Microsoft.AspNetCore.Http.HttpResults.NoContent;
using Contracts.Abstractions.Protobuf;
using Grpc.Core;
using MassTransit;
using Microsoft.AspNetCore.Http.HttpResults;
using static Microsoft.AspNetCore.Http.TypedResults;
using IMessage = Google.Protobuf.IMessage;
using NotFound = Microsoft.AspNetCore.Http.HttpResults.NotFound;

namespace WebApplication1.Abstractions
{
    public static class ApplicationApi
    {
        public static async Task<Results<Accepted, ValidationProblem>> SendCommandAsync<TCommand>(ICommand<TCommand> request)
        where TCommand : class, ICommand
        {
            return request.IsValid(out var errors) ? await SendAsync() : ValidationProblem(errors);

            async Task<Accepted> SendAsync()
            {
                Console.WriteLine(Address<TCommand>());
                var endpoint = await request.Bus.GetSendEndpoint(Address<TCommand>());
                await endpoint.Send(request.Command, request.CancellationToken);
                return Accepted("");
            }
        }

        public static async Task<Results<Ok<TResponse>, NotFound, ValidationProblem, Problem>> GetAsync<TClient, TResponse>
        (IQuery<TClient> query, Func<TClient, CancellationToken, AsyncUnaryCall<GetResponse>> getAsync)
        where TClient : ClientBase<TClient>
        where TResponse : IMessage, new()
        {
            return query.IsValid(out var errors) ? await ResponseAsync() : ValidationProblem(errors);

            async Task<Results<Ok<TResponse>, NotFound, ValidationProblem, Problem>> ResponseAsync()
            {
                var response = await getAsync(query.Client, query.CancellationToken);

                return response.OneOfCase switch
                {
                    GetResponse.OneOfOneofCase.NotFound => NotFound(),
                    GetResponse.OneOfOneofCase.Projection when response.Projection.TryUnpack<TResponse>(out var result) => Ok(result),
                    _ => new Problem()
                };
            }
        }

        public static async Task<Results<Ok<FindResult<TResponse>>, NoContent, ValidationProblem, Problem>> FindAsync<TClient, TResponse>
        (IQuery<TClient> query, Func<TClient, CancellationToken, AsyncUnaryCall<FindResponse>> listAsync)
        where TClient : ClientBase<TClient>
        where TResponse : IMessage, new()
        {
            return query.IsValid(out var errors) ? await ResponseAsync() : ValidationProblem(errors);

            async Task<Results<Ok<FindResult<TResponse>>, NoContent, ValidationProblem, Problem>> ResponseAsync()
            {
                var response = await listAsync(query.Client, query.CancellationToken);

                return response.OneOfCase switch
                {
                    FindResponse.OneOfOneofCase.NoContent => NoContent(),
                    FindResponse.OneOfOneofCase.FindResult => Ok<FindResult<TResponse>>(response.FindResult),
                    _ => new Problem()
                };
            }
        }

        public static async Task<Results<Ok<PagedResult<TResponse>>, NoContent, ValidationProblem, Problem>> ListAsync<TClient, TResponse>
        (IQuery<TClient> query, Func<TClient, CancellationToken, AsyncUnaryCall<ListResponse>> listAsync)
        where TClient : ClientBase<TClient>
        where TResponse : IMessage, new()
        {
            return query.IsValid(out var errors) ? await ResponseAsync() : ValidationProblem(errors);

            async Task<Results<Ok<PagedResult<TResponse>>, NoContent, ValidationProblem, Problem>> ResponseAsync()
            {
                var response = await listAsync(query.Client, query.CancellationToken);

                return response.OneOfCase switch
                {
                    ListResponse.OneOfOneofCase.NoContent => NoContent(),
                    ListResponse.OneOfOneofCase.PagedResult => Ok<PagedResult<TResponse>>(response.PagedResult),
                    _ => new Problem()
                };
            }
        }

        private static Uri Address<T>()
        => new($"exchange:{KebabCaseEndpointNameFormatter.Instance.SanitizeName(typeof(T).Name)}");
    }
}
