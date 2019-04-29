using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emf.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Emf.Core;

namespace Emf.Pages.Employees
{
    public class ListModel : PageModel
    {
        private readonly IEmployeeData _employeeData;
        private readonly IDepartmentData _departmentData;

        public IEnumerable<Employee> Employees { get; set; }
        public List<Department> Departments { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? DeptId { get; set; }


        public ListModel(IEmployeeData employeeData, IDepartmentData departmentData)
        {
            _employeeData = employeeData;
            _departmentData = departmentData;
        }

        public void OnGet(int deptID)
        {
            Departments = _departmentData.GetAll().ToList();

            // if there is no dept id then we should display all employees
            if (DeptId.HasValue)
            {
                Employees = _employeeData.GetEmployeesByDeptId(DeptId.Value);
            }
            else
            {
                Employees = _employeeData.GetAll();
            }
        }
    }
}