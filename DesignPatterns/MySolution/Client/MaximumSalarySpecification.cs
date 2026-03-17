using Specifications.Library.Base;

namespace Client
{

    // DSL = Domain Specific Language specification for maximum salary requirement
    public class MaximumSalarySpecification : Specification<Employee>
    {
        private readonly decimal _maxSal;

        public MaximumSalarySpecification(decimal maxSal)
        {
            this._maxSal = maxSal;
        }

        public override bool IsSatisfiedBy(Employee candidate)
        {
            return candidate.Salary <= _maxSal;
        }
    }
}
