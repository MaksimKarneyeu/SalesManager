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
    public class DocumentsController : ApiController
    {
        private readonly IDocumentService documentService;
        public DocumentsController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }

        [HttpGet]
        public async Task<ICollection<Document>> GetDocumentsAsync()
        {
            try
            {
                return await documentService.GetDocumentsAsync();
            }
            catch (Exception)
            {
                var message = "Error occured while updating documents.";
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
