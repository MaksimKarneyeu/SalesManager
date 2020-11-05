using SalesManager.Common.Files;
using SalesManager.Common.Models;
using SalesManager.Data.BulkOperations;
using SalesManager.Data.Entities;
using SalesManager.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SalesManager.Business.Services
{
    public class SaleService : ISaleService
    {
        private readonly IBulkOperator bulkOperator;
        private readonly ICsvReader csvReader;
        private readonly IRepository<Document> documentRepository;
        private readonly IRepository<Sale> saleRepository;
        private readonly IDataTableService dataTableService;

        public SaleService(IBulkOperator bulkOperator, ICsvReader csvReader, IRepository<Document> documentRepository, IRepository<Sale> saleRepository, IDataTableService dataTableService)
        {
            this.bulkOperator = bulkOperator;
            this.csvReader = csvReader;
            this.documentRepository = documentRepository;
            this.saleRepository = saleRepository;
            this.dataTableService = dataTableService;
        }

        public async Task<Guid> UploadCsvAsync(CsvFile file)
        {
            var documents = await documentRepository.GetAllAsync();
            var document = documents.FirstOrDefault(doc => doc.Name == file.Name);
            var dataTable = csvReader.BuildFromCsvFile(file.Data);
            dataTable = dataTableService.ConverSaleColumnTypes(dataTable);

            if (document != null)
            {
                bulkOperator.BulkUpdate(dataTable, document.ID);
                return document.ID;
            }

            document = new Document
            {
                Name = file.Name,
                StartUploadTime = DateTime.UtcNow,
                UploadedBy = HttpContext.Current.Request.LogonUserIdentity.Name
            };

            document = documentRepository.Add(document);

            bulkOperator.BulkInsert(dataTable, document.ID);

            document.EndUploadTime = DateTime.UtcNow;
            await documentRepository.UpdateAsync(document, document.ID);
            return document.ID;
        }
        public async Task<IList<Sale>> GetSalesByDocumentIdAsync(Guid id)
        {
            var sales = await saleRepository.GetAllAsync();
            return sales.Where(x => x.DocumentID == id).ToList();
        }

        public async Task<Sale> GetSaleByIdAsync(Guid id) => 
            await saleRepository.GetByIdAsync(id);

        public void AddSale(Sale sale) => saleRepository.Add(sale);

        public async Task<Sale> UpdateSaleAsync(Sale sale)
        {
            var existing = await saleRepository.GetByIdAsync(sale.ID);
            sale.DocumentID = existing.DocumentID;
            return await saleRepository.UpdateAsync(sale, sale.ID);
        }

        public async Task DeleteSaleAsync(Guid id)
        {
            var sale = await saleRepository.GetByIdAsync(id);
            await saleRepository.DeleteAsync(sale);
        }
        
    }
}
