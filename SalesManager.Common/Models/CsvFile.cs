using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.Common.Models
{
    public class CsvFile
    {
        public string Name { get; set; }
        public Stream Data { get; set; }
    }
}
