using SalesManager.Business.Services;
using SalesManager.Common.Models;
using SalesManager.Logger;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace SalesManager.WebAPI.Controllers
{  
    public class SalesImportController : ApiController
    {
        private readonly ISaleService salesService;
        public SalesImportController(ISaleService salesService)
        {
            this.salesService = salesService;
        }
        
        [HttpPost]
        public async Task UploadCsv()
        {
            string message = null;
            HttpResponseMessage response = null;
                      
            var file = BuildFileFromRequest();
            if(file == null)
            {
                message = "Csv file is empty";
                LoggerStub.Log(message);
                response = new HttpResponseMessage()
                {
                    Content = new StringContent(message, Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.NotFound
                };
                throw new HttpResponseException(response);
            }
            try
            {
                await salesService.UploadCsvAsync(file);
            }
            catch (Exception e)
            {
                message = "Error occurs while uploading csv file";
                LoggerStub.Log(message, e);
                response = new HttpResponseMessage()
                {
                    Content = new StringContent(message, Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.InternalServerError
                };

                throw new HttpResponseException(response);                
            }           

        }
        
        private CsvFile BuildFileFromRequest() 
        {
            CsvFile file = null;
            var files = HttpContext.Current.Request.Files;
            if (files?.Count > 0)
            {
                var receviedFile = files[0];
                file = new CsvFile 
                { 
                    Name = receviedFile.FileName, Data = receviedFile.InputStream
                };
            }
            return file;
        }
    }
}