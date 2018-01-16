using CarService.Web.ViewModels.Shared.Address;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CarService.Web.ViewModels.Employee
{
    public class EmployeeEdit
    {
        public int Id { get; set; }

        [DisplayName("Imię")]
        [Required(ErrorMessage ="Pole Imię jest wymagane")]
        public string Name { get; set; }

        [DisplayName("Nazwisko")]
        [Required(ErrorMessage = "Pole Nazwisko jest wymagane")]
        public string Surname { get; set; }

        [DisplayName("Pesel")]
        [Required(ErrorMessage = "Pole Pesel jest wymagane")]
        public string Pesel{ get; set; }

        [DisplayName("Telefon")]
        [Required(ErrorMessage = "Pole Telefon jest wymagane")]
        public string Phone{ get; set; }

        [DisplayName("Stanowisko")]
        [Required(ErrorMessage = "Pole Stanowisko jest wymagane")]
        public int PositionId{ get; set; }
        public IEnumerable<SelectListItem> Positions { get; set; }

        [DisplayName("Pensja")]
        public decimal? Salary { get; set; }

        public bool EmployeeIsAdministrator{ get; set; }

        public bool IsAdmin { get; set; }

        public AddressEdit AddressEdit { get; set; }

        private readonly Data.Models.Employee _employee;
        
        public EmployeeEdit(Data.Models.Employee employee)
        {
            _employee = employee;

            Id = employee.Id;
            Name = employee.Name;
            Surname = employee.Surname;
            Pesel = employee.Pesel;
            Phone = employee.Phone;
            AddressEdit = new AddressEdit(employee.Address);
            Salary = employee.Salary;
            EmployeeIsAdministrator = employee.User.Role.Id == (int)Data.Enums.Role.Admin;
            if (employee.Position != null)
                PositionId = employee.Position.Id;
        }

        public Data.Models.Employee ToEmployee()
        {
            _employee.ModifyDate = DateTime.Now;
            _employee.Name = Name;
            _employee.Surname = Surname;
            _employee.Pesel = Pesel;
            _employee.Phone = Phone;
            if (IsAdmin)
            {
                _employee.Salary = Salary ?? 0;
                _employee.User.Role_Id = EmployeeIsAdministrator ? (int)Data.Enums.Role.Admin : (int)Data.Enums.Role.Employee;
            }
            if (_employee.Position == null)
                _employee.Position = new Data.Models.Position { Id = PositionId };
            _employee.Address = _employee.Address == null ? AddressEdit.ToNewAddress() : AddressEdit.ToAddress();
            if (!_employee.IsVerified)
                _employee.IsVerified = true;

            return _employee;
        }
    }
}