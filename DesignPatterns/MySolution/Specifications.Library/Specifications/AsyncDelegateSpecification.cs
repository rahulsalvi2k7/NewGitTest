using Specifications.Library.Base;

namespace Specifications.Library.Specifications
{
    public class AsyncDelegateSpecification<T> : AsyncSpecification<T>
    {
        private readonly Func<T, Task<bool>> _predicate;

        public AsyncDelegateSpecification(Func<T, Task<bool>> predicate)
        {
            _predicate = predicate;
        }

        public override Task<bool> IsSatisfiedByAsync(T candidate, CancellationToken ct = default)
            => _predicate(candidate);
    }
}
