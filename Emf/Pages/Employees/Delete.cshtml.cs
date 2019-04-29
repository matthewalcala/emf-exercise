using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emf.Core;
using Emf.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Emf.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeData _employeeData;

        public Employee Employee { get; set; }

        public DeleteModel(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        public IActionResult OnGet(int id)
        {
            Employee = _employeeData.GetById(id);

            if (Employee == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var Employee = _employeeData.Delete(id);
            _employeeData.Commit();

            if (Employee == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{Employee.FirstName} {Employee.LastName} deleted";
            return RedirectToPage("./List");
        }
    }
}