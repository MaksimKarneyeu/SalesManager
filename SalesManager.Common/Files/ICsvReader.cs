using SalesManager.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.Common.Files
{
    public interface ICsvReader
    {
        DataTable BuildFromCsvFile(Stream data);
    }
}
