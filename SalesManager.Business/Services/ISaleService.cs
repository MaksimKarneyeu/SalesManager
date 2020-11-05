using SalesManager.Common.Models;
using SalesManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.Business.Services
{
    public interface ISaleService
    {
        Task<Guid> UploadCsvAsync(CsvFile file);

        Task<IList<Sale>> GetSalesByDocumentIdAsync(Guid id);
        Task<Sale> GetSaleByIdAsync(Guid id);

        void AddSale(Sale sale);

        Task<Sale> UpdateSaleAsync(Sale sale);

        Task DeleteSaleAsync(Guid id);
    }
}
