using Specifications.Library.Base;
using Specifications.Library.Interfaces;

namespace Specifications.Library.Specifications
{
    public class NotSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _spec;

        public NotSpecification(ISpecification<T> spec)
        {
            _spec = spec;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return !_spec.IsSatisfiedBy(candidate);
        }
    }
}
