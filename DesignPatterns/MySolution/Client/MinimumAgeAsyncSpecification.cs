using Specifications.Library.Base;

namespace Client
{
    // DSL = Domain Specific Language specification for minimum age requirement
    public class MinimumAgeAsyncSpecification : AsyncSpecification<Employee>
    {
        private readonly int _minAge;

        public MinimumAgeAsyncSpecification(int minAge)
        {
            this._minAge = minAge;
        }

        public override Task<bool> IsSatisfiedByAsync(Employee candidate, CancellationToken cancellationToken)
        {
            return Task.FromResult(candidate.Age >= _minAge);
        }
    }
}
