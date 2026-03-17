namespace Client
{
    public class Employee
    {
        public string Name { get; init; }
        public int Age { get; init; }
        public decimal Salary { get; init; }

        public Employee(string name, int age, decimal salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }
    }
}
