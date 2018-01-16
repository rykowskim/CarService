using CarService.Data.Models;
using CarService.Web.ViewModels.Employee;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Schedule> GetSchedule(int employeeId)
        {
            var employee = Employees.FirstOrDefault(x => x.Id == employeeId);
            return employee.Order.Select(n => new Schedule
            {
                OrderId = n.Id,
                CreateDate = n.CreateDate.ToString("yyyy-MM-dd"),
                Car = string.Format("{0} {1}", n.Car.Mark, n.Car.Model),
                CustomerName = string.Format("{0} {1}", n.Customer.Name, n.Customer.Surname),
                OrderStatus = n.OrderStatus.Name
            }).OrderByDescending(c => c.CreateDate);
        }

        public IEnumerable<ResultItem> Search(EmployeeSearchItem item)
        {
            var records = Employees.Where(x => (string.IsNullOrEmpty(item.Name) || x.Name.Contains(item.Name)) &&
                                            (string.IsNullOrEmpty(item.Surname) || x.Surname.Contains(item.Surname)) &&
                                            (string.IsNullOrEmpty(item.Email) || x.Surname.Contains(item.Email)) &&
                                            (item.PositionId == null || x.Position.Id == item.PositionId) && x.IsActive);

            return records.Select(n => new ResultItem
            {
                Id = n.Id,
                FullName = string.Format("{0} {1}", n.Name, n.Surname),
                Email = n.User.Email,
                Phone = n.Phone,
                Position = n.Position.Name,
                CountOfTasks = n.Order.Count
            });
        }
    }
}