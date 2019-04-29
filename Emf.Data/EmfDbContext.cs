using Emf.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emf.Data
{
    public class EmfDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public EmfDbContext(DbContextOptions<EmfDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "IT Web Internal", Description = "Internal Web App Division", DepartmentType = DepartmentType.IT },
                new Department { Id = 2, Name = "Sitecore Web Dev", Description = "Sitecore Web Development Division", DepartmentType = DepartmentType.IT },
                new Department { Id = 3, Name = "News", Description = "News division", DepartmentType = DepartmentType.Business }

            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee {Id = 1,
                    FirstName = "Mateo",
                    LastName = "Alcala",
                    Address1 = "1000 Main Street",
                    Address2 = "",
                    City = "Lincoln",
                    State = "CA",
                    Zipcode = "95648",
                    DepartmentId = 1,
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
                    Email = "jc@gmail.com",
                    Phone = "1234567890"
                },
                  new Employee
                  {
                      Id = 4,
                      FirstName = "John",
                      LastName = "Rapid",
                      Address1 = "1000 Main Street",
                      Address2 = "",
                      City = "Lincoln",
                      State = "CA",
                      Zipcode = "95648",
                      DepartmentId = 1,
                      Email = "mattalcala@gmail.com",
                      Phone = "1234567890",
                  },
                new Employee
                {
                    Id = 5,
                    FirstName = "Max",
                    LastName = "Power",
                    Address1 = "1000 Blues St",
                    Address2 = "",
                    City = "Folsom",
                    State = "CA",
                    Zipcode = "95887",
                    DepartmentId = 2,
                    Email = "jc@gmail.com",
                    Phone = "1234567890"
                },
                 new Employee
                 {
                     Id = 6,
                     FirstName = "Kid",
                     LastName = "Man",
                     Address1 = "1000 Blues St",
                     Address2 = "",
                     City = "Folsom",
                     State = "CA",
                     Zipcode = "95887",
                     DepartmentId = 2,
                     Email = "jc@gmail.com",
                     Phone = "1234567890"
                 },
                  new Employee
                  {
                      Id = 7,
                      FirstName = "Bob",
                      LastName = "Bee",
                      Address1 = "1000 Main Street",
                      Address2 = "",
                      City = "Lincoln",
                      State = "CA",
                      Zipcode = "95648",
                      DepartmentId = 1,
                      Email = "mattalcala@gmail.com",
                      Phone = "1234567890",
                  },
                new Employee
                {
                    Id = 8,
                    FirstName = "Koda",
                    LastName = "Tuko",
                    Address1 = "1000 Blues St",
                    Address2 = "",
                    City = "Folsom",
                    State = "CA",
                    Zipcode = "95887",
                    DepartmentId = 2,
                    Email = "jc@gmail.com",
                    Phone = "1234567890"
                },
                 new Employee
                 {
                     Id = 9,
                     FirstName = "Luke",
                     LastName = "Skywalker",
                     Address1 = "1000 Blues St",
                     Address2 = "",
                     City = "Folsom",
                     State = "CA",
                     Zipcode = "95887",
                     DepartmentId = 2,
                     Email = "jc@gmail.com",
                     Phone = "1234567890"
                 }
                 ,
                  new Employee
                  {
                      Id = 10,
                      FirstName = "Steve",
                      LastName = "Gates",
                      Address1 = "1000 Main Street",
                      Address2 = "",
                      City = "Lincoln",
                      State = "CA",
                      Zipcode = "95648",
                      DepartmentId = 1,
                      Email = "mattalcala@gmail.com",
                      Phone = "1234567890",
                  },
                new Employee
                {
                    Id = 11,
                    FirstName = "Billy",
                    LastName = "Jobs",
                    Address1 = "1000 Blues St",
                    Address2 = "",
                    City = "Folsom",
                    State = "CA",
                    Zipcode = "95887",
                    DepartmentId = 2,
                    Email = "jc@gmail.com",
                    Phone = "1234567890"
                },
                 new Employee
                 {
                     Id = 12,
                     FirstName = "Outa",
                     LastName = "Names",
                     Address1 = "1000 Blues St",
                     Address2 = "",
                     City = "Folsom",
                     State = "CA",
                     Zipcode = "95887",
                     DepartmentId = 2,
                     Email = "jc@gmail.com",
                     Phone = "1234567890"
                 }
            );
        }
    }
}
