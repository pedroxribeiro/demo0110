using System.IO;
using System.Threading.Tasks;

namespace Employee.Infra.Files
{
    public static class EmployeeFileHelper
    {
        // Path for the employee data file
        private static readonly string filePath = "EMPLOYEE.DAT";

        public static async Task AppendRecordAsync(string record)
        {
            // Open the file in append mode and write the record as a new line
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                await writer.WriteLineAsync(record);
            }
        }
    }
}
