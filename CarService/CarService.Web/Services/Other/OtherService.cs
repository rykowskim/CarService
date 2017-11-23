using CarService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarService.Web.Services.Other
{
    public static class OtherService
    {
        public static IEnumerable<SelectListItem> GetOrderTypes()
        {
            var dbContext = new CarServiceContext();

            return dbContext.OrderType.Select(n => new SelectListItem
            {
                Value = n.Id.ToString(),
                Text = n.Name
            });
        }

        public static IEnumerable<SelectListItem> GetOrderStatuses()
        {
            var dbContext = new CarServiceContext();

            return dbContext.OrderStatus.Select(n => new SelectListItem
            {
                Value = n.Id.ToString(),
                Text = n.Name
            });
        }
    }
}