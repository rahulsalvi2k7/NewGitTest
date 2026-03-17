using Specifications.Library.Interfaces;
using Specifications.Library.Specifications;

namespace Specifications.Library.Base
{
    public abstract class AsyncSpecification<T> : IAsyncSpecification<T>
    {
        public abstract Task<bool> IsSatisfiedByAsync(T candidate, CancellationToken cancellationToken);

        public IAsyncSpecification<T> And(IAsyncSpecification<T> other) => new AndAsyncSpecification<T>(this, other);

        public IAsyncSpecification<T> Not() => new NotAsyncSpecification<T>(this);

        public IAsyncSpecification<T> Or(IAsyncSpecification<T> other) => new OrAsyncSpecification<T>(this, other);
    }
}
