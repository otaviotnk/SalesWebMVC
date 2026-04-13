using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Interfaces;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;
using SalesWebMVC.Models.ViewModels;

namespace SalesWebMVC.Controllers
{
    public class HomeController(ISalesRecordService salesRecordService, ISellerService sellerService, IDepartmentService departmentService) : Controller
    {
        private readonly ISalesRecordService _salesRecordService = salesRecordService;
        private readonly ISellerService _sellerService = sellerService;
        private readonly IDepartmentService _departmentService = departmentService;

        public async Task<IActionResult> Index()
        {
            var allSales = await _salesRecordService.FindByDateAsync(null, null);
            var sellers = await _sellerService.FindAllAsync();
            var departments = await _departmentService.FindAllAsync();

            var viewModel = new HomeIndexViewModel
            {
                TotalSellers = sellers.Count,
                TotalDepartments = departments.Count,
                TotalRevenue = allSales.Where(s => s.Status == SalesStatus.Billed).Sum(s => s.Amount),
                PendingSales = allSales.Count(s => s.Status == SalesStatus.Pending),
                RecentSales = allSales.Take(8).ToList()
            };

            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Sales Web MVC App demo.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
