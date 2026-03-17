using Specifications.Library.Interfaces;
using Specifications.Library.Specifications;

namespace Specifications.Library.Base
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T candidate);

        public ISpecification<T> And(ISpecification<T> other) => new AndSpecification<T>(this, other);

        public ISpecification<T> Not() => new NotSpecification<T>(this);

        public ISpecification<T> Or(ISpecification<T> other) => new OrSpecification<T>(this, other);
    }
}
