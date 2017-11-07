using CarService.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace CarService.Web.Services.Employee
{
    public partial class EmployeeService : IEmployeeService
    {
        private CarServiceContext dbContext = new CarServiceContext();

        public IEnumerable<Data.Models.Employee> Employees
        {
            get { return dbContext.Employee; }
        }

        public void Create(Data.Models.Employee employee)
        {
            dbContext.Employee.Add(employee);
            dbContext.SaveChanges();
        }
    }
}