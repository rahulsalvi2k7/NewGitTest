using Newtonsoft.Json.Linq;
using Specifications.Library.Interfaces;
using Specifications.Library.Specifications;

namespace Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var employee = new Employee("John Doe", 30, 100.23m);

            /*
            var ageSpec = new MinimumAgeSpecification(18);
            var maxSalarySpec = new MaximumSalarySpecification(50m);
            var cheapSpec = ageSpec.And(maxSalarySpec);
            bool isSatisfied = cheapSpec.IsSatisfiedBy(employee);
            */

            var data = JObject.FromObject(new
            {
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
            });

            var minSalarySpec = new MinimumSalarySpecification(80m);

            /*
            var expensiveSpec = minSalarySpec.IsSatisfiedBy(data);
            */

            var employeeValidator = new EmployeeValidatorService();

            var result = await employeeValidator.ValidateEmployeeAsync(data, CancellationToken.None);
        }
    }

    public class EmployeeValidatorService
    {
        private readonly IAsyncSpecification<JObject> asyncSpecification;

        private readonly ISpecification<JObject> minSalarySpec = new MinimumSalarySpecification(80m);

        public EmployeeValidatorService()
        {
            asyncSpecification = Spec
                .For<JObject>()
                .WhenAsync(e => Task.FromResult(minSalarySpec.IsSatisfiedBy(e)))
                .And(e => (int?)e["Age"] == 30)
                .Named("MinimumSalaryAndAgeThirty")
                .Build();
        }

        public async Task<bool> ValidateEmployeeAsync(JObject employee, CancellationToken cancellationToken)
        {
            return await asyncSpecification.IsSatisfiedByAsync(employee, cancellationToken);
        }
    }
}
