﻿using CarService.Web.ViewModels.Employee;
using CarService.Web.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Employee
{
    public partial class EmployeeController
    {
        [HttpGet, Route("Employee/View/{id}")]
        public ActionResult View(int id, string returnUrl)
        {
            var employee = _employeeService.Employees.FirstOrDefault(x => x.Id == id && x.IsActive);
            if (employee == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var viewModel = new EmployeeEdit(employee)
            {
                Positions = _postionService.Positions.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }),
                IsAdmin = User.IsInRole(Data.Enums.Role.Admin.ToString()),
                OrderList = employee.Order.OrderByDescending(x => x.ModifyDate).Take(5).Select(n => new OrderList
                {
                    Id = n.Id,
                    Customer = string.Format("{0} {1}", n.Customer.Name, n.Customer.Surname),
                    Status = n.OrderStatus.Name 
                })
            };
            return View(viewModel);
        }

        [HttpPost, Route("Employee/View/{id}"), ActionName("View")]
        public ActionResult ViewPost(int id, string returnUrl)
        {
            var employee = _employeeService.Employees.FirstOrDefault(x => x.Id == id && x.IsActive);
            if (employee == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var viewModel = new EmployeeEdit(employee)
            {
                Positions = _postionService.Positions.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }),
                IsAdmin = User.IsInRole(Data.Enums.Role.Admin.ToString())
            };

            if (!TryUpdateModel(viewModel) || !ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                var toModel = viewModel.ToEmployee();
                _employeeService.Update(toModel);
            }
            catch (Exception ex)
            {
                return View(viewModel);
                throw ex;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}