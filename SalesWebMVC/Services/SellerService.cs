using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using SalesWebMVC.Data;


namespace SalesWebMVC.Services
{
    public class SellerService
    {
        // criar dependencia
        private readonly SalesWebMVCContext _context;

        public SellerService( SalesWebMVCContext context)
        {
            _context = context;
        }

        //retorna lista com todos os vendedores

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }


    }
}
