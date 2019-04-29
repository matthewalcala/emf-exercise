using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emf.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Emf.Core;

namespace Emf.Pages.Departments
{
    public class ListModel : PageModel
    {
        private readonly IDepartmentData _departmentData;

        public IEnumerable<Department> Departments { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }

        public ListModel(IDepartmentData departmentData)
        {
            _departmentData = departmentData;
        }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(SearchName))
            {
                Departments = _departmentData.GetAll();
            }
            else
            {
                Departments = _departmentData.GetDepartmentsByName(SearchName);
            }
        }

    }
}