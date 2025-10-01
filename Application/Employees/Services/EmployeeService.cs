using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Employee.Application.Employees.Models;
using Employee.Domain.Employees;
using Employee.Infra.Files;
using Employee.Domain.SeedWork;

namespace Employee.Application.Employees.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        public EmployeeService(INotification notification) : base(notification)
        {
        }

        public async Task<EmployeeResponse> AddEmployeeAsync(EmployeeRequest request)
        {
            // Validate ID: exactly 4 numeric digits
            if (!Regex.IsMatch(request.Id, @"^\d{4}$"))
            {
                Notification.Add("Invalid ID. It must be numeric with exactly 4 digits.");
                return new EmployeeResponse { Success = false };
            }

            // Validate Name: must be alphanumeric (allowing spaces)
            if (!Regex.IsMatch(request.Name, @"^[A-Za-z0-9\s]+$"))
            {
                Notification.Add("Invalid Name. It must be alphanumeric.");
                return new EmployeeResponse { Success = false };
            }

            // Validate Age: exactly 2 numeric digits
            if (!Regex.IsMatch(request.Age, @"^\d{2}$"))
            {
                Notification.Add("Invalid Age. It must be numeric with exactly 2 digits.");
                return new EmployeeResponse { Success = false };
            }

            // Validate Address: must be alphanumeric (allowing spaces)
            if (!Regex.IsMatch(request.Address, @"^[A-Za-z0-9\s]+$"))
            {
                Notification.Add("Invalid Address. It must be alphanumeric.");
                return new EmployeeResponse { Success = false };
            }

            // Create the Employee domain entity
            var employee = Employee.Create(request.Id, request.Name, request.Age, request.Address);

            try
            {
                // Build the record string in a line sequential format
                string recordLine = $"{employee.Id} {employee.Name} {employee.Age} {employee.Address}";
                // Append the record at the end of the file EMPLOYEE.DAT
                await EmployeeFileHelper.AppendRecordAsync(recordLine);
            }
            catch (Exception ex)
            {
                Notification.Add("Failed to write to file: " + ex.Message);
                return new EmployeeResponse { Success = false };
            }

            var response = new EmployeeResponse
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Success = true
            };

            // Finalize the process by ending application execution after successful recording
            Environment.Exit(0);

            return response; // This line will not be reached
        }
    }
}
