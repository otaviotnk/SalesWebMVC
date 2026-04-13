using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Data
{
    public class SeedingService(SalesWebMVCContext context)
    {
        private readonly SalesWebMVCContext _context = context;

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return;
            }

            Department department1 = new("Computers");
            Department department2 = new("Electronics");
            Department department3 = new("Fashion");
            Department department4 = new("Books");

            Seller seller1 = new("Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.00, department1);
            Seller seller2 = new("Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.00, department2);
            Seller seller3 = new("Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.00, department1);
            Seller seller4 = new("Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.00, department4);
            Seller sellere5 = new("Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.00, department3);
            Seller seller6 = new("Alex Pink", "alex.p@gmail.com", new DateTime(1997, 3, 4), 3000.00, department2);

            var salesRecords = new List<SalesRecord>()
            {
                new(RandomDatePreviousYear(), 11000.0, SalesStatus.Billed, seller1),
                new(RandomDatePreviousYear(), 11000.0, SalesStatus.Billed, seller1),
                new(RandomDatePreviousYear(), 7000.0, SalesStatus.Billed, sellere5),
                new(RandomDatePreviousYear(), 4000.0, SalesStatus.Canceled, seller4),
                new(RandomDatePreviousYear(), 8000.0, SalesStatus.Billed, seller1),
                new(RandomDatePreviousYear(), 3000.0, SalesStatus.Billed, seller3),
                new(RandomDatePreviousYear(), 2000.0, SalesStatus.Billed, seller1),
                new(RandomDatePreviousYear(), 13000.0, SalesStatus.Billed, seller2),
                new(RandomDatePreviousYear(), 4000.0, SalesStatus.Billed, seller4),
                new(RandomDatePreviousYear(), 11000.0, SalesStatus.Pending, seller6),
                new(RandomDatePreviousYear(), 9000.0, SalesStatus.Billed, seller6),
                new(RandomDatePreviousYear(), 6000.0, SalesStatus.Billed, seller2),
                new(RandomDatePreviousYear(), 7000.0, SalesStatus.Pending, seller3),
                new(RandomDatePreviousYear(), 10000.0, SalesStatus.Billed, seller4),
                new(RandomDatePreviousYear(), 3000.0, SalesStatus.Billed, sellere5),
                new(RandomDatePreviousYear(), 4000.0, SalesStatus.Billed, seller1),
                new(RandomDatePreviousYear(), 2000.0, SalesStatus.Billed, seller4),
                new(RandomDatePreviousYear(), 12000.0, SalesStatus.Billed, seller1),
                new(RandomDatePreviousYear(), 6000.0, SalesStatus.Billed, seller3),
                new(RandomDatePreviousYear(), 8000.0, SalesStatus.Billed, sellere5),
                new(RandomDatePreviousYear(), 8000.0, SalesStatus.Billed, seller6),
                new(RandomDatePreviousYear(), 9000.0, SalesStatus.Billed, seller2),
                new(RandomDatePreviousYear(), 4000.0, SalesStatus.Billed, seller4),
                new(RandomDatePreviousYear(), 11000.0, SalesStatus.Canceled, seller2),
                new(RandomDatePreviousYear(), 8000.0, SalesStatus.Billed, sellere5),
                new(RandomDatePreviousYear(), 7000.0, SalesStatus.Billed, seller3),
                new(RandomDatePreviousYear(), 5000.0, SalesStatus.Billed, seller4),
                new(RandomDatePreviousYear(), 9000.0, SalesStatus.Pending, seller1),
                new(RandomDatePreviousYear(), 4000.0, SalesStatus.Billed, seller3),
                new(RandomDatePreviousYear(), 12000.0, SalesStatus.Billed, sellere5),
                new(RandomDatePreviousYear(), 5000.0, SalesStatus.Billed, seller2)
            };

            //adicionar no banco de dados
            _context.Department.AddRange(department1, department2, department3, department4);
            _context.Seller.AddRange(seller1, seller2, seller3, seller4, sellere5, seller6);
            _context.SalesRecord.AddRange(salesRecords);

            //confirma e salva as alteracoes
            _context.SaveChanges();
        }

        private static DateTime RandomDatePreviousYear()
        {
            var random = new Random();
            var previousYear = DateTime.Now.Year - 1;
            var start = new DateTime(previousYear, 1, 1);
            var totalDays = (new DateTime(previousYear, 12, 31) - start).Days;
            return start.AddDays(random.Next(totalDays + 1));
        }
    }
}
