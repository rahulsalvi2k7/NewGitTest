using Newtonsoft.Json.Linq;
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

    public class MinimumSalarySpecification : Specification<JObject>
    {
        private readonly decimal _minSal;
        private const string SalaryField = "Salary";

        public MinimumSalarySpecification(decimal minSal)
        {
            this._minSal = minSal;
        }

        public override bool IsSatisfiedBy(JObject candidate)
        {
            var salaryToken = candidate[SalaryField];

            if (salaryToken == null || !decimal.TryParse(salaryToken.ToString(), out decimal salary))
            {
                return false;
            }

            return salary >= _minSal;
        }
    }
}
