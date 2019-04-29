using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Emf.Core
{
    public enum DepartmentType
    {
        None,
        IT,
        Business,
        Maintenance,
    }

    public class Department
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public DepartmentType DepartmentType { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
