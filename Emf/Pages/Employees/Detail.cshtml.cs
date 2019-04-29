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
    public class DetailModel : PageModel
    {
        private readonly IEmployeeData _employeeData;

        [TempData]
        public string Message { get; set; }

        public Employee Employee { get; set; }

        public DetailModel(IEmployeeData employeeData)
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
    }
}