using SalesWebMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesWebMVC.Interfaces
{
    public interface ISellerService
    {
        public Task<List<Seller>> FindAllAsync();
        public Task InsertAsync(Seller obj);
        public Task<Seller> FindByIdAsync(int id);
        public Task RemoveAsync(int id);
        public Task UpdateAsync(Seller obj);
    }
}
