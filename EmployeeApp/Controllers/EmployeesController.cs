using EmployeeApp.Data;
using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeDataDbContext employeeDbContext;

        public EmployeesController(EmployeeDataDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeViewRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeViewRequest.Name,
                City = addEmployeeViewRequest.City,
                State = addEmployeeViewRequest.State,
                Salary = addEmployeeViewRequest.Salary,
            };
            await employeeDbContext.Employees.AddAsync(employee);
            await employeeDbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }
    }
}
