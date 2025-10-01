namespace Employee.Application.Employees.Models
{
    public class EmployeeRequest
    {
        // ID must be numeric of 4 digits (e.g. "0123")
        public string Id { get; set; } = "";

        // Name must be alphanumeric
        public string Name { get; set; } = "";

        // Age must be numeric of 2 digits (e.g. "25")
        public string Age { get; set; } = "";

        // Address must be alphanumeric
        public string Address { get; set; } = "";
    }
}
