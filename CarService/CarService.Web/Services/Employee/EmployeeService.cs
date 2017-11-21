using CarService.Data.Models;
using System.Collections.Generic;

namespace CarService.Web.Services.Employee
{
    public partial class EmployeeService : IEmployeeService
    {
        private CarServiceContext dbContext = new CarServiceContext();

        public IEnumerable<Data.Models.Employee> Employees => dbContext.Employee;

        public void Create(Data.Models.Employee employee) 
        {
            dbContext.Entry(employee.User).State = System.Data.Entity.EntityState.Unchanged;
            dbContext.Employee.Add(employee);
            dbContext.SaveChanges();
        }

        public void Update(Data.Models.Employee employee)
        {
            dbContext.Entry(employee.Position).State = System.Data.Entity.EntityState.Unchanged;
            //dbContext.Entry(employee).CurrentValues.SetValues(employee);
            dbContext.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}