using SalesWebMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesWebMVC.Interfaces
{
    public interface IDepartmentService
    {
        public Task<List<Department>> FindAllAsync();
        public void Insert(Seller obj);
    }
}
