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
    public class DeleteModel : PageModel
    {
        private readonly IDepartmentData _departmentData;

        public Department Department { get; set; }

        public DeleteModel(IDepartmentData departmentData)
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

        public IActionResult OnPost(int id)
        {
            var department = _departmentData.Delete(id);
            _departmentData.Commit();

            if (department == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{department.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}