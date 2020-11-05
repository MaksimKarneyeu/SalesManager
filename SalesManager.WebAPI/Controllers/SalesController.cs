using SalesManager.Business.Services;
using SalesManager.Data.Entities;
using SalesManager.Logger;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SalesManager.WebAPI.Controllers
{
    public class SalesController : ApiController
    {
        private readonly ISaleService saleService;
        public SalesController(ISaleService saleService)
        {
            this.saleService = saleService;
        }

        [HttpGet]
        public async Task<IList<Sale>> GetSalesByDocumentIdAsync(Guid id)
        {
            try
            {
                return await saleService.GetSalesByDocumentIdAsync(id);
            }
            catch (Exception)
            {
                var message = "Error occured while getting sales sale.";
                LoggerStub.Log(message);
                var response = new HttpResponseMessage()
                {
                    Content = new StringContent(message, System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.InternalServerError
                };

                throw new HttpResponseException(response);
            }

        }

        [HttpGet]
        public async Task<Sale> GetSaleByIdAsync(Guid id)
        {
            try
            {
                return await saleService.GetSaleByIdAsync(id);
            }
            catch (Exception)
            {
                var message = "Error occured while getting sale.";
                LoggerStub.Log(message);
                var response = new HttpResponseMessage()
                {
                    Content = new StringContent(message, System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.InternalServerError
                };

                throw new HttpResponseException(response);
            }

        }

        [HttpPut]
        public async Task UpdateSaleAsync([FromBody] Sale sale)
        {
            try
            {
                await saleService.UpdateSaleAsync(sale);
            }
            catch (Exception)
            {
                var message = "Error occured while updating sale.";
                LoggerStub.Log(message);
                var response = new HttpResponseMessage()
                {
                    Content = new StringContent(message, System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.InternalServerError
                };

                throw new HttpResponseException(response);
            }

        }

        [HttpDelete]
        public async Task DeleteSaleAsync(Guid id)
        {   
            try
            {
                await saleService.DeleteSaleAsync(id);
            }
            catch (Exception)
            {
                var message = "Error occured while deleting sale.";
                LoggerStub.Log(message);
                var response = new HttpResponseMessage()
                {
                    Content = new StringContent(message, System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.InternalServerError
                };

                throw new HttpResponseException(response);
            }            
        }
    }
}
