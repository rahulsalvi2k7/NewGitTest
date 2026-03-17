using Specifications.Library.Base;
using Specifications.Library.Interfaces;

namespace Specifications.Library.Specifications
{
    public class AndAsyncSpecification<T> : AsyncSpecification<T>
    {
        private readonly IAsyncSpecification<T> _left;
        private readonly IAsyncSpecification<T> _right;

        public AndAsyncSpecification(IAsyncSpecification<T> left, IAsyncSpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override async Task<bool> IsSatisfiedByAsync(T candidate, CancellationToken cancellationToken)
        {
            return await _left.IsSatisfiedByAsync(candidate, cancellationToken) &&
                   await _right.IsSatisfiedByAsync(candidate, cancellationToken);
        }
    }
}
