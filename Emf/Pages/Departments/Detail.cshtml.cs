using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emf.Core;
using Emf.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Emf.Pages.Departments
{
    public class DetailModel : PageModel
    {
        private readonly IDepartmentData _departmentData;

        [TempData]
        public string Message { get; set; }

        public Department Department { get; set; }

        public DetailModel(IDepartmentData departmentData)
        {
            _departmentData = departmentData;
        }

        public IActionResult OnGet(int id)
        {
            Department = _departmentData.GetById(id);

            if (Department == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}