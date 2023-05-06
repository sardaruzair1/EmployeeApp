using EmployeeApp.Data;
using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task <IActionResult> Index()
        {
         var employees =  await employeeDbContext.Employees.ToListAsync();
            return View(employees);
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
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var employee = await employeeDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if(employee != null)
            {
                var ViewModel = new EmployeeUpdate()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    City = employee.City,
                    State = employee.State,
                    Salary = employee.Salary,
                };
                return await Task.Run(()=> View("View",ViewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(EmployeeUpdate model)
        {
            var employee = await employeeDbContext.Employees.FindAsync(model.Id);
            if(employee != null)
            {
                employee.Name = model.Name;
                employee.City = model.City;
                employee.State = model.State;
                employee.Salary = model.Salary;
                
                await employeeDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(EmployeeUpdate model)
        {
            var employee = await employeeDbContext.Employees.FindAsync(model.Id);
            if (employee != null)
            {
                employeeDbContext.Employees.Remove(employee);
                await employeeDbContext.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
    }
}
