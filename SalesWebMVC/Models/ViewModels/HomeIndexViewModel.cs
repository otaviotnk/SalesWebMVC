using SalesWebMVC.Models.Enums;
using System.Collections.Generic;

namespace SalesWebMVC.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public int TotalSellers { get; set; }
        public int TotalDepartments { get; set; }
        public double TotalRevenue { get; set; }
        public int PendingSales { get; set; }
        public List<SalesRecord> RecentSales { get; set; } = [];
    }
}
