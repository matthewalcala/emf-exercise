using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emf.Core;
using Emf.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Emf.Pages.Departments
{
    public class EditModel : PageModel
    {
        private readonly IDepartmentData _departmentData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Department Department { get; set; }
        public IEnumerable<SelectListItem> DepartmentTypes { get; set; }

        public EditModel(IDepartmentData departmentData, IHtmlHelper htmlHelper)
        {
            _departmentData = departmentData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? id)
        {
            DepartmentTypes = _htmlHelper.GetEnumSelectList<DepartmentType>();

            if (id.HasValue)
            {
                Department = _departmentData.GetById(id.Value);
            }
            else
            {
                Department = new Department();
            }

            if (Department == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }


        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                DepartmentTypes = _htmlHelper.GetEnumSelectList<DepartmentType>();
                return Page();
            }

            if (Department.Id > 0)
            {
                _departmentData.Update(Department);
            }
            else
            {
                _departmentData.Add(Department);
            }

            _departmentData.Commit();
            TempData["Message"] = "Department saved!";
            return RedirectToPage("./Detail", new { id = Department.Id });

        }
    }
}