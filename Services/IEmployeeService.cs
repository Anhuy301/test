using Web_Test_DevExpress_ClaudeAI.Models;

namespace Web_Test_DevExpress_ClaudeAI.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<bool> EmployeeCodeExistsAsync(string code, int? excludeId = null);
    }
}