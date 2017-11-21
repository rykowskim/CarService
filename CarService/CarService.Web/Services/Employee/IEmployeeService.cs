using System.Collections.Generic;

namespace CarService.Web.Services.Employee
{
    public interface IEmployeeService
    {
        IEnumerable<Data.Models.Employee> Employees { get; }

        void Create(Data.Models.Employee employee);
        void Update(Data.Models.Employee employee);
    }
}
