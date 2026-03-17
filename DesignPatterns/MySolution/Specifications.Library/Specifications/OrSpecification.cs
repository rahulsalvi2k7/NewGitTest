using Specifications.Library.Base;
using Specifications.Library.Interfaces;

namespace Specifications.Library.Specifications
{
    public class OrSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return _left.IsSatisfiedBy(candidate) &&
                   _right.IsSatisfiedBy(candidate);
        }
    }
}
