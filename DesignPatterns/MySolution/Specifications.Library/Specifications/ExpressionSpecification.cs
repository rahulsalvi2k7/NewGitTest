using Specifications.Library.Base;

namespace Specifications.Library.Specifications
{
    public class ExpressionSpecification<T> : AsyncSpecification<T>
    {
        private readonly Func<T, bool> _predicate;

        public ExpressionSpecification(Func<T, bool> predicate)
        {
            _predicate = predicate;
        }

        public override Task<bool> IsSatisfiedByAsync(T candidate, CancellationToken ct = default)
            => Task.FromResult(_predicate(candidate));
    }
}
