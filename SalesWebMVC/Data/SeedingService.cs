using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;
using System;
using System.Linq;

namespace SalesWebMVC.Data
{
    public class SeedingService(SalesWebMVCContext context)
    {
        private readonly SalesWebMVCContext _context = context;

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
                return;

            Department[] departments =
            [
                new("Computers"),
                new("Electronics"),
                new("Fashion"),
                new("Books")
            ];

            Seller[] sellers =
            [
                new("Bob Brown",   "bob@gmail.com",    new(1998,  4, 21), 1000.00, departments[0]),
                new("Maria Green", "maria@gmail.com",  new(1979, 12, 31), 3500.00, departments[1]),
                new("Alex Grey",   "alex@gmail.com",   new(1988,  1, 15), 2200.00, departments[0]),
                new("Martha Red",  "martha@gmail.com", new(1993, 11, 30), 3000.00, departments[3]),
                new("Donald Blue", "donald@gmail.com", new(2000,  1,  9), 4000.00, departments[2]),
                new("Alex Pink",   "alex.p@gmail.com", new(1997,  3,  4), 3000.00, departments[1]),
            ];

            SalesRecord[] salesRecords =
            [
                new(RandDate(), 11000.0, SalesStatus.Billed,   sellers[0]),
                new(RandDate(), 11000.0, SalesStatus.Billed,   sellers[0]),
                new(RandDate(),  7000.0, SalesStatus.Billed,   sellers[4]),
                new(RandDate(),  4000.0, SalesStatus.Canceled, sellers[3]),
                new(RandDate(),  8000.0, SalesStatus.Billed,   sellers[0]),
                new(RandDate(),  3000.0, SalesStatus.Billed,   sellers[2]),
                new(RandDate(),  2000.0, SalesStatus.Billed,   sellers[0]),
                new(RandDate(), 13000.0, SalesStatus.Billed,   sellers[1]),
                new(RandDate(),  4000.0, SalesStatus.Billed,   sellers[3]),
                new(RandDate(), 11000.0, SalesStatus.Pending,  sellers[5]),
                new(RandDate(),  9000.0, SalesStatus.Billed,   sellers[5]),
                new(RandDate(),  6000.0, SalesStatus.Billed,   sellers[1]),
                new(RandDate(),  7000.0, SalesStatus.Pending,  sellers[2]),
                new(RandDate(), 10000.0, SalesStatus.Billed,   sellers[3]),
                new(RandDate(),  3000.0, SalesStatus.Billed,   sellers[4]),
                new(RandDate(),  4000.0, SalesStatus.Billed,   sellers[0]),
                new(RandDate(),  2000.0, SalesStatus.Billed,   sellers[3]),
                new(RandDate(), 12000.0, SalesStatus.Billed,   sellers[0]),
                new(RandDate(),  6000.0, SalesStatus.Billed,   sellers[2]),
                new(RandDate(),  8000.0, SalesStatus.Billed,   sellers[4]),
                new(RandDate(),  8000.0, SalesStatus.Billed,   sellers[5]),
                new(RandDate(),  9000.0, SalesStatus.Billed,   sellers[1]),
                new(RandDate(),  4000.0, SalesStatus.Billed,   sellers[3]),
                new(RandDate(), 11000.0, SalesStatus.Canceled, sellers[1]),
                new(RandDate(),  8000.0, SalesStatus.Billed,   sellers[4]),
                new(RandDate(),  7000.0, SalesStatus.Billed,   sellers[2]),
                new(RandDate(),  5000.0, SalesStatus.Billed,   sellers[3]),
                new(RandDate(),  9000.0, SalesStatus.Pending,  sellers[0]),
                new(RandDate(),  4000.0, SalesStatus.Billed,   sellers[2]),
                new(RandDate(), 12000.0, SalesStatus.Billed,   sellers[4]),
                new(RandDate(),  5000.0, SalesStatus.Billed,   sellers[1]),
            ];

            _context.Department.AddRange(departments);
            _context.Seller.AddRange(sellers);
            _context.SalesRecord.AddRange(salesRecords);
            _context.SaveChanges();
        }

        private static DateTime RandDate()
        {
            var previousYear = DateTime.Now.Year - 1;
            var start = new DateTime(previousYear, 1, 1);
            var totalDays = (new DateTime(previousYear, 12, 31) - start).Days;
            return start.AddDays(Random.Shared.Next(totalDays + 1));
        }
    }
}
