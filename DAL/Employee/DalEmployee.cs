using Entities;
using Microsoft.Extensions.Configuration;
using DAL.Employee;
using DAL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL.Business
{
    public class DalEmployee: IDalEmployee
    {
        private const string Key = "Urls:ApiEmployee";
        private readonly ApiServices _apiServices;
        private readonly IConfiguration _configuration;


        public DalEmployee(ApiServices apiServices, IConfiguration configuration)
        {
            _apiServices = apiServices;
            _configuration = configuration;
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            string? url = $"{_configuration.GetSection(Key).Value}/employee/{id}";

            var data = await _apiServices.GetDataAsync<Response<EmployeeDto>>(url);
            if (data is not null && data.Status.Equals("success"))
            {
                return data.Data;
            }

            return null;
        }

        public async Task<List<EmployeeDto>> GetEmployeesAsync()
        {
            string? url = $"{_configuration.GetSection(Key).Value}/employees";

            var data = await _apiServices.GetDataAsync<Response<List<EmployeeDto>>>(url);
            if (data is not null && data.Status.Equals("success"))
            {
                return data.Data;
            }

            return null;
        }
    }
}
