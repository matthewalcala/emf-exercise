using System.Collections.Generic;
using System.Text;
using Emf.Core;

namespace Emf.Data
{
    public interface IEmployeeData
    {
        IEnumerable<Employee> GetEmployeesByDeptId(int id);
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        Employee Update(Employee updatedEmployee);
        Employee Add(Employee newEmployee);
        Employee Delete(int id);
        int Commit();
    }
}
