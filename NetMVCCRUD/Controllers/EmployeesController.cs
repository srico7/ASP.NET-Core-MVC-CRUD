using Microsoft.AspNetCore.Mvc;
using NetMVCCRUD.Data;
using NetMVCCRUD.Models;
using NetMVCCRUD.Models.Domain;

namespace NetMVCCRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDbContext mVCDbContext;

        public EmployeesController(MVCDbContext mVCDbContext)
        {
            this.mVCDbContext = mVCDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                Department = addEmployeeRequest.Department,
                DateOfBirth = addEmployeeRequest.DateOfBirth
            };

            await mVCDbContext.Employees.AddAsync(employee);
            await mVCDbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }
    }
}
