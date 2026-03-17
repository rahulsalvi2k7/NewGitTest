namespace Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var employee = new Employee("John Doe", 30, 100.23m);

            var ageSpec = new MinimumAgeSpecification(18);
            var maxSalarySpec = new MaximumSalarySpecification(50m);

            var cheapSpec = ageSpec.And(maxSalarySpec);

            bool isSatisfied = cheapSpec.IsSatisfiedBy(employee);
        }
    }
}
