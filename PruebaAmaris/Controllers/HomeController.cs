using Microsoft.AspNetCore.Mvc;
using PruebaAmaris.Models;
using DAL.Business;
using DAL.Employee;
using System.Diagnostics;
using Services.Employee;
using Entities;
using Newtonsoft.Json.Linq;

namespace PruebaAmaris.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SrvEmployee _srvEmployee; 
        public HomeController(ILogger<HomeController> logger, SrvEmployee srvEmployee)
        {
            _logger = logger;
            _srvEmployee = srvEmployee;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> Index(string message)
        {
            var employees = await _srvEmployee.GetAllEmployeesAsync();
            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.Message = message;
            }
            
            return View(employees ?? new List<EmployeeDto>());
        }

        [HttpGet("Search")]
        public async Task<ActionResult<EmployeeDto>> Search(string sid)
        {
            int id;
            bool success = int.TryParse(sid, out id);
            if (!success)
                return RedirectToAction("Index", new { message = $"Id no valido - {sid}" });

            var employee = await _srvEmployee.GetEmployeeByIdAsync(id);
            if (employee is null)
            {
                return RedirectToAction("Index", new { message = $"Empleado {sid} no encontrado" });
            }
            return View(employee);
        }

    }
}