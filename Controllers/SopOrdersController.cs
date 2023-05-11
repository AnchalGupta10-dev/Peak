using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Peak.Helper;
using Peak.Models;
using Peak.Queries;

namespace Peak.Controllers
{
    public class SopOrdersController : Controller
    {
        private readonly Stp_Oms_LiveContext _context;

        public SopOrdersController(Stp_Oms_LiveContext context)
        {
            _context = context;
        }

        //GET: SopOrders/GetCategory
        public async Task<IActionResult> GetCategory(DateTime? startDate, DateTime? endDate)
        {
            //var sql = System.IO.File.ReadAllText("Scripts\\GetCategory.sql");
            //var response = _context.GetCategoryResults.FromSqlRaw(sql).ToList();

            // check for the dates and set as per the passed start date and end date
            startDate = (startDate == null ? DateTime.Now : startDate);
            endDate = (endDate == null ? DateTime.Now : endDate);
            //converting date for SQL
            var response = SqlHelper.GetOrderCount(_context, 
                startDate.Value.ToString("yyyy-MM-dd HH:mm:ss"), 
                endDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));

            return Ok(response);
        }

        public async Task<IActionResult> GetCategoryView(DateTime? startDate, DateTime? endDate)
        {
            var data = (OkObjectResult)GetCategory(startDate, endDate).Result;
            decimal totalSales = 0;
            int totalOrder = 0;
            if(data.Value != null)
            {
                var salesData = (List<GetCategoryResult>)data.Value;
                salesData.ForEach(s =>
                {
                    totalSales += s.sales.Value;
                    totalOrder += s.OrderCount.Value;
                });
            }
            ViewData["TotalSales"] = totalSales;
            ViewData["TotalOrder"] = totalOrder;
            ViewData["StartDate"] = startDate == null ? null : startDate.Value;
            ViewData["EndDate"] = endDate == null ? null : endDate.Value;
            return View(data.Value);
        }

        // GET: SopOrders/GetTopFiveProduct

        public async Task<IActionResult> GetTopFiveProduct(DateTime? startDate, DateTime? endDate)
        {
            //var sql = System.IO.File.ReadAllText("Scripts\\GetTopFive products.sql");
            //var response = _context.GetTopFiveProductsResult.FromSqlRaw(sql).ToList();

            startDate = (startDate == null ? DateTime.Now : startDate);
            endDate = (endDate == null ? DateTime.Now : endDate);
            var response = SqlHelper.GetTopFiveProduct(_context,
                startDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                endDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
             return Ok(response);
        }
        public async Task<IActionResult> GetTopFiveProductView(DateTime? startDate, DateTime? endDate)
        {
            var data = (OkObjectResult)GetTopFiveProduct(startDate,endDate).Result;
            var topFiveData = ((List<GetTopFiveProductsResult>)data.Value).Take(5);
            ViewData["StartDate"] = startDate == null ? null : startDate.Value;
            ViewData["EndDate"] = endDate == null ? null : endDate.Value;
            return View(topFiveData);
        }

        private object GetTopFiveProduct(object startDate, object endDate)
        {
            throw new NotImplementedException();
        }

        private bool SopOrderExists(long id)
        {
          return (_context.SopOrders?.Any(e => e.SopOrderId == id)).GetValueOrDefault();
        }
    }
}
