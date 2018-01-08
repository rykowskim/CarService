using CarService.Web.ViewModels.Order;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Order
{
    public partial class OrderController
    {
        [HttpGet, Route("Order/Edit/{id}")]
        public ActionResult Edit([Bind(Prefix = "id")]int orderId, string returnUrl)
        {
            var order = _orderService.Orders.Where(x => x.Id == orderId && x.IsActive).FirstOrDefault();
            if (order == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //przenieść do serwisu
            var viewModel = new EditOrder(order)
            {
                Employees = _employeeService.Employees.Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = string.Format("{0} {1}", n.Name, n.Surname)
                }),
                ReturnUrl = returnUrl,
                Cost = _costService.Costs.FirstOrDefault(x => x.Order.Id == order.Id)
            };
            return View(viewModel);
        }

        [HttpPost, Route("Order/Edit/{id}"), ActionName("Edit")]
        public ActionResult EditPost([Bind(Prefix = "id")]int orderId, string returnUrl)
        {
            var order = _orderService.Orders.Where(x => x.Id == orderId && x.IsActive).FirstOrDefault();
            if (order == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // przenieść do serwisu
            var viewModel = new EditOrder(order)
            {
                Employees = _employeeService.Employees.Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = string.Format("{0} {1}", n.Name, n.Surname)
                }),
                ReturnUrl = returnUrl
            };

            if (!TryUpdateModel(viewModel) || !ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                _orderService.Update(viewModel.ToEdit());

                if (viewModel.OrderStatusId == 4) //do odbioru
                    return RedirectToAction("Create", "Cost", new { id = order.Id, returnUrl = HttpContext.Request.Url });

                return Redirect(viewModel.ReturnUrl);
            }
            catch (Exception ex)
            {
                return View(viewModel);
                throw ex;
            }
        }
    }
}