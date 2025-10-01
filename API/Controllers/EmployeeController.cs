using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Employee.Application.Employees.Models;
using Employee.Application.Employees.Services;
using Employee.Domain.SeedWork;

namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService, INotification notification) : base(notification)
        {
            _employeeService = employeeService;
        }

        // POST api/Employee
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeRequest request)
        {
            var response = await _employeeService.AddEmployeeAsync(request);
            return Response(response);
        }
    }
}
