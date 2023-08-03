using DAL.Employee;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Employee
{
    public class SrvEmployee
    {
        private readonly IDalEmployee _dalEmployee;
        public SrvEmployee(IDalEmployee dalEmployee)
        {
            _dalEmployee = dalEmployee;
        }

        public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _dalEmployee.GetEmployeesAsync();
            if (employees is not null)
                employees.ForEach(_ => _.Employee_anual_salary = CalculateAnualSalary(_.Employee_salary));

            return employees;
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var employe = await _dalEmployee.GetEmployeeByIdAsync(id);
            if (employe is not null)
                employe.Employee_anual_salary = CalculateAnualSalary(employe.Employee_salary);

            return employe;
        }

        public int CalculateAnualSalary(int salary) => salary * 12;
    }
}
