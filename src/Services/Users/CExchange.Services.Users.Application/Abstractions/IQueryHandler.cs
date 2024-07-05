// Application/Abstractions/IQueryHandler.cs
using System.Threading;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.Abstractions
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : class
    {
        Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
    }
}
