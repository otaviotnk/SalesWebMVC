using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Interfaces
{
    public interface ISalesRecordService
    {
        public Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate);
        public Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate);
    }
}
