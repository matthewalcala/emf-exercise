using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emf.Core;
using Emf.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Emf.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeData _employeeData;
        private readonly IDepartmentData _departmentData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Employee Employee { get; set; }

        public List<Department> Departments { get; set; }

        public EditModel(IEmployeeData employeeData, IDepartmentData departmentData, IHtmlHelper htmlHelper)
        {
            _employeeData = employeeData;
            _departmentData = departmentData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? id)
        {
            Departments = _departmentData.GetAll().ToList();
           
            if (id.HasValue)
            {
                Employee = _employeeData.GetById(id.Value);
            }
            else
            {
                Employee = new Employee();
            }

            if (Employee == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }


        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                Departments = _departmentData.GetDepartmentsByName(null).ToList();
                return Page();
            }

            if (Employee.Id > 0)
            {
                _employeeData.Update(Employee);
            }
            else
            {
                _employeeData.Add(Employee);
            }

            _employeeData.Commit();
            TempData["Message"] = "Employee saved!";
            return RedirectToPage("./Detail", new { id = Employee.Id });

        }
    }
}