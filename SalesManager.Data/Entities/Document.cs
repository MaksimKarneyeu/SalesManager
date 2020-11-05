using System;
using System.Collections.Generic;

namespace SalesManager.Data.Entities
{
    public class Document : BaseEntity
    {   
        public DateTime? StartUploadTime { get; set; }
        public DateTime? EndUploadTime { get; set; }
        public string UploadedBy { get; set; }

        public string Name { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
