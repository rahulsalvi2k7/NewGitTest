using Specifications.Library.Base;

namespace Client
{
    // DSL = Domain Specific Language specification for maximum salary requirement
    public class MaximumSalaryAsyncSpecification : AsyncSpecification<Employee>
    {
        private readonly decimal _maxSal;

        public MaximumSalaryAsyncSpecification(decimal maxSal)
        {
            this._maxSal = maxSal;
        }

        public override Task<bool> IsSatisfiedByAsync(Employee candidate, CancellationToken cancellationToken)
        {
            return Task.FromResult(candidate.Salary <= _maxSal);
        }
    }
}
