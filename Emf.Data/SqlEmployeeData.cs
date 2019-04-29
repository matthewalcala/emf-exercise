using System.Collections.Generic;
using Emf.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Emf.Data
{
    public class SqlEmployeeData : IEmployeeData
    {
        private readonly EmfDbContext _dbContext;

        public SqlEmployeeData(EmfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Employee Add(Employee newEmployee)
        {
            _dbContext.Add(newEmployee);
            return newEmployee;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public Employee Delete(int id)
        {
            var Employee = GetById(id);
            if (Employee != null)
            {
                _dbContext.Employees.Remove(Employee);
            }

            return Employee;
        }


        public IEnumerable<Employee> GetAll()
        {
            return _dbContext.Employees.OrderBy(e => e.LastName).ToList();
        }

        public Employee GetById(int id)
        {
            var employees = _dbContext.Employees.Include(d => d.Department);
            return employees.SingleOrDefault(d => d.Id == id);
        }

        public IEnumerable<Employee> GetEmployeesByDeptId(int id)
        {
            var query = from e in _dbContext.Employees
                        where e.DepartmentId == id
                        orderby e.LastName
                        select e;

            return query;
        }

        public Employee Update(Employee updatedEmployee)
        {
            var entity = _dbContext.Employees.Attach(updatedEmployee);
            entity.State = EntityState.Modified;
            return updatedEmployee;
        }
    }
}
