using Specifications.Library.Base;
using Specifications.Library.Interfaces;

namespace Specifications.Library.Specifications
{
    public class NotAsyncSpecification<T> : AsyncSpecification<T>
    {
        private readonly IAsyncSpecification<T> _spec;

        public NotAsyncSpecification(IAsyncSpecification<T> left)
        {
            _spec = left;
        }

        public override async Task<bool> IsSatisfiedByAsync(T candidate, CancellationToken cancellationToken)
        {
            return !await _spec.IsSatisfiedByAsync(candidate, cancellationToken);
        }
    }
}
