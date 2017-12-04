using CarService.Web.Services.Other;
using CarService.Web.ViewModels.Order;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Order
{
    public partial class OrderController
    {
        [HttpGet, Route("Order/Edit/{id}")]
        public ActionResult Edit([Bind(Prefix = "id")]int orderId)
        {
            var order = _orderService.Orders.Where(x => x.Id == orderId && x.IsActive).FirstOrDefault();
            if (order == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var viewModel = new EditOrder(order)
            {
                Id = order.Id,
                Car = string.Format("{0} {1}", order.Car.Mark, order.Car.Model),
                Customer = string.Format("{0} {1}", order.Customer.Name, order.Customer.Surname),
                Employee = string.Format("{0} {1}", order.Employee.Name, order.Employee.Surname),
                OrderStatus = order.OrderStatus.Name,
                OrderType = order.OrderType.Name,
                RepairDescription = order.RepairDescription,
                EmployeeId = order.Employee.Id,
                OrderStatusId = order.OrderStatus.Id,
                OrderStatuses = OtherService.GetOrderStatuses(),
                Employees = _employeeService.Employees.Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = string.Format("{0} {1}", n.Name, n.Surname)
                }),
            };

            return View(viewModel);
        }

        [HttpPost, Route("Order/Edit/{id}"), ActionName("Edit")]
        public ActionResult EditPost([Bind(Prefix = "id")]int orderId)
        {
            var order = _orderService.Orders.Where(x => x.Id == orderId && x.IsActive).FirstOrDefault();
            if (order == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var viewModel = new EditOrder(order)
            {
                Id = order.Id,
                Car = string.Format("{0} {1}", order.Car.Mark, order.Car.Model),
                Customer = string.Format("{0} {1}", order.Customer.Name, order.Customer.Surname),
                Employee = string.Format("{0} {1}", order.Employee.Name, order.Employee.Surname),
                OrderStatus = order.OrderStatus.Name,
                OrderType = order.OrderType.Name,
                RepairDescription = order.RepairDescription,
                EmployeeId = order.Employee.Id,
                OrderStatusId = order.OrderStatus.Id,
                OrderStatuses = OtherService.GetOrderStatuses(),
                Employees = _employeeService.Employees.Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = string.Format("{0} {1}", n.Name, n.Surname)
                }),
            };

            if (!TryUpdateModel(viewModel))
            {
                return View(viewModel);
            }

            try
            {
                var toEdit = viewModel.ToEdit();
                _orderService.Update(toEdit);

                return RedirectToAction("Edit", "Order", new { id = order.Id });
            }
            catch (Exception ex)
            {
                return View(viewModel);
                throw ex;
            }
        }
    }
}