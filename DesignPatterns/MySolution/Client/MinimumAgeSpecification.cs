using Specifications.Library.Base;

namespace Client
{
    // DSL = Domain Specific Language specification for minimum age requirement
    public class MinimumAgeSpecification : Specification<Employee>
    {
        private readonly int _minAge;

        public MinimumAgeSpecification(int minAge)
        {
            this._minAge = minAge;
        }

        public override bool IsSatisfiedBy(Employee candidate)
        {
            return candidate.Age >= _minAge;
        }
    }
}
