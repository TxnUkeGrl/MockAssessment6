using Microsoft.AspNetCore.Mvc;
using Mock6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mock6.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDBContext _context;

        public EmployeeController(EmployeeDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        public IActionResult EmployeeForm()
        {
            return View();
        }

        public IActionResult RetirementInfo(int Id) //Employee employee.Id
        {
            var foundEmployee = _context.Employees.Find(Id);
            var retiringEmployee = new Retirement();

            if(foundEmployee.Age > 60)
            {
                retiringEmployee.CanRetire = true;
                retiringEmployee.Benefits = (float)foundEmployee.Salary;
            }
            else
            {
                retiringEmployee.CanRetire = false;
            retiringEmployee.Benefits = (float)(foundEmployee.Salary * 0.6m);
            }

            

            return View(retiringEmployee);
        }
    }
}
