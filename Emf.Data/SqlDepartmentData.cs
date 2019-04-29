using System.Collections.Generic;
using Emf.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Emf.Data
{
    public class SqlDepartmentData : IDepartmentData
    {
        private readonly EmfDbContext _dbContext;

        public SqlDepartmentData(EmfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Department Add(Department newDepartment)
        {
            _dbContext.Add(newDepartment);
            return newDepartment;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public Department Delete(int id)
        {
            var department = GetById(id);
            if (department != null)
            {
                // Todo: Get all the employees and set dept id to null. For now just cascade delete :)
                _dbContext.Departments.Remove(department);
            }

            return department;
        }

        public IEnumerable<Department> GetAll()
        {
            return _dbContext.Departments
                .OrderBy(d => d.Name)
                .ToList();
        }

        public Department GetById(int id)
        {
            return _dbContext.Departments.Find(id);
        }

        public IEnumerable<Department> GetDepartmentsByName(string name)
        {
            var query = from d in _dbContext.Departments
                        where d.Name.ToUpper().Contains(name.ToUpper()) || string.IsNullOrEmpty(name)
                        orderby d.Name
                        select d;

            return query;
        }

        public Department Update(Department updatedDepartment)
        {
            var entity = _dbContext.Departments.Attach(updatedDepartment);
            entity.State = EntityState.Modified;
            return updatedDepartment;
        }
    }
}
