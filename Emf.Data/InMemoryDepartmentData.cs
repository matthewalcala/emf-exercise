using System;
using System.Collections.Generic;
using System.Linq;
using Emf.Core;

namespace Emf.Data
{
    public class InMemoryDepartmentData : IDepartmentData
    {
        private List<Department> _departments;

        public InMemoryDepartmentData()
        {
            
            _departments = new List<Department>()
            {
                new Department {Id = 1, Name = "IT Web Internal", Description = "Internal Web App Division", DepartmentType = DepartmentType.IT},
                new Department {Id = 2, Name = "Sitecore Web Dev", Description = "Sitecore Web Development Division", DepartmentType = DepartmentType.IT},
                new Department {Id = 3, Name = "News", Description = "News division", DepartmentType = DepartmentType.Business}
            };
        }

        public IEnumerable<Department> GetAll()
        {
            return _departments
                .OrderBy(d => d.Name)
                .ToList();
        }

        public IEnumerable<Department> GetDepartmentsByName(string name)
        {
           return _departments
                .Where(d => d.Name.ToUpper().Contains(name.ToUpper()))
                .OrderBy(d => d.Name)
                .ToList();
        }

        public Department GetById(int id)
        {
            return _departments.SingleOrDefault(d => d.Id == id);
        }

        public Department Add(Department newDepartment)
        {
            _departments.Add(newDepartment);
            newDepartment.Id = _departments.Max(d => d.Id) + 1;

            return newDepartment;
        }

            public Department Update(Department updatedDepartment)
        {
            var department = _departments.SingleOrDefault(d => d.Id == updatedDepartment.Id);

            //Todo: use automapper
            if (department != null)
            {
                department.Name = updatedDepartment.Name;
                department.Description = updatedDepartment.Description;
                department.DepartmentType = updatedDepartment.DepartmentType;
            }

            return department;
        }

        public int Commit()
        {
            return 0;
        }

        public Department Delete(int id)
        {
            var department = _departments.SingleOrDefault(d => d.Id == id);

            if (department != null)
            {
                _departments.Remove(department);
            }

            return department;
        }
    }
}
