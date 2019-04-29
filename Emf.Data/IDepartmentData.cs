using System.Collections.Generic;
using System.Text;
using Emf.Core;

namespace Emf.Data
{
    public interface IDepartmentData
    {
        IEnumerable<Department> GetDepartmentsByName(string name);
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        Department Update(Department updatedDepartment);
        Department Add(Department newDepartment);
        Department Delete(int id);
        int Commit();
    }
}
