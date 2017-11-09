using CarService.Web.ViewModels.Shared.Address;

namespace CarService.Web.ViewModels.Employee
{
    public class EmployeeEdit
    {
        public AddressEdit AddressEdit { get; set; }
        
        public EmployeeEdit()
        {
            AddressEdit = new AddressEdit();
        }
    }
}