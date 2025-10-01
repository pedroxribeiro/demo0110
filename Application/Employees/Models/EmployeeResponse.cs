using Employee.Application.Common;

namespace Employee.Application.Employees.Models
{
    public class EmployeeResponse : BaseResponse
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Age { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
