using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Employee
{
    public interface IDalEmployee
    {
        Task<List<EmployeeDto>> GetEmployeesAsync();

        Task<EmployeeDto> GetEmployeeByIdAsync(int id);
    }
}
