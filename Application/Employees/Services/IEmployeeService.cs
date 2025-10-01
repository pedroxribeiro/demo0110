using System.Threading.Tasks;
using Employee.Application.Employees.Models;

namespace Employee.Application.Employees.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeResponse> AddEmployeeAsync(EmployeeRequest request);
    }
}
