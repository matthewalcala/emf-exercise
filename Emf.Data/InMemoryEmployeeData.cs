using System;
using System.Collections.Generic;
using System.Linq;
using Emf.Core;

namespace Emf.Data
{
    public class InMemoryEmployeeData : IEmployeeData
    {
        private List<Employee> _Employees;

        public InMemoryEmployeeData()
        {
            _Employees = new List<Employee>()
            {
                new Employee {Id = 1,
                    FirstName = "Mateo",
                    LastName = "Alcala",
                    Address1 = "1000 Main Street",
                    Address2 = "",
                    City = "Lincoln",
                    State = "CA",
                    Zipcode = "95648",
                    DepartmentId = 1,
                    Department = new Department
                    {
                        Id = 1,
                        Name = "IT Web Internal"
                    },
                    Email = "mattalcala@gmail.com",
                    Phone = "1234567890",
                },
                new Employee {Id = 2,
                    FirstName = "Johnny",
                    LastName = "Cash",
                    Address1 = "1000 Blues St",
                    Address2 = "",
                    City = "Folsom",
                    State = "CA",
                    Zipcode = "95887",
                    DepartmentId = 2,
                    Department = new Department
                    {
                        Id = 2,
                        Name = "Sitecore Web Dev"
                    },
                    Email = "jc@gmail.com",
                    Phone = "1234567890"
                },
                 new Employee {Id = 3,
                    FirstName = "George",
                    LastName = "Lucas",
                    Address1 = "1000 Blues St",
                    Address2 = "",
                    City = "Folsom",
                    State = "CA",
                    Zipcode = "95887",
                    DepartmentId = 2,
                     Department = new Department
                    {
                        Id = 2,
                        Name = "Sitecore Web Dev"
                    },
                    Email = "jc@gmail.com",
                    Phone = "1234567890"
                }
            };
        }

        public IEnumerable<Employee> GetAll()
        {
            return _Employees.OrderBy(e => e.LastName).ToList();
        }

        public IEnumerable<Employee> GetEmployeesByDeptId(int id)
        {
            return _Employees
                .Where(e => e.DepartmentId == id)
                .OrderBy(e => e.LastName)
                .ToList();
        }

        public Employee GetById(int id)
        {
            var employee = _Employees.SingleOrDefault(e => e.Id == id);

            // Load the dept manually for in mem version only
            InMemoryDepartmentData department = new InMemoryDepartmentData();
            employee.Department = department.GetById(employee.DepartmentId);

            return employee;
        }

        public Employee Add(Employee newEmployee)
        {
            _Employees.Add(newEmployee);
            newEmployee.Id = _Employees.Max(e => e.Id) + 1;

            return newEmployee;
        }

        public Employee Update(Employee updatedEmployee)
        {
            var Employee = _Employees.SingleOrDefault(e => e.Id == updatedEmployee.Id);

            //Todo: use automapper
            if (Employee != null)
            {
                Employee.FirstName = updatedEmployee.FirstName;
                Employee.LastName = updatedEmployee.LastName;
                Employee.Address1 = updatedEmployee.Address1;
                Employee.Address2 = updatedEmployee.Address2;
                Employee.City = updatedEmployee.City;
                Employee.State = updatedEmployee.State;
                Employee.Zipcode = updatedEmployee.Zipcode;
                Employee.Phone = updatedEmployee.Phone;
                Employee.Email = updatedEmployee.Email;
            }

            return Employee;
        }

        public int Commit()
        {
            return 0;
        }

        public Employee Delete(int id)
        {
            var Employee = _Employees.SingleOrDefault(e => e.Id == id);

            if (Employee != null)
            {
                _Employees.Remove(Employee);
            }

            return Employee;
        }
    }
}
