namespace Employee.Domain.Employees
{
    public class Employee
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Age { get; private set; }
        public string Address { get; private set; }

        protected Employee() { }

        private Employee(string id, string name, string age, string address)
        {
            Id = id;
            Name = name;
            Age = age;
            Address = address;
        }

        public static Employee Create(string id, string name, string age, string address)
        {
            return new Employee(id, name, age, address);
        }
    }
}
