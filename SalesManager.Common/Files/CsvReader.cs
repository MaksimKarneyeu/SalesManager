using GenericParsing;
using SalesManager.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.Common.Files
{
    public class CsvReader : ICsvReader
    {
        public DataTable BuildFromCsvFile(Stream data)
        {
            using (GenericParserAdapter parser = CsvParserFactory(data))
            {
                return parser.GetDataTable();              
            }
        }

        private GenericParserAdapter CsvParserFactory(Stream data)
        {
            GenericParserAdapter parser = new GenericParserAdapter();

            parser.SetDataSource(new StreamReader(data)); 
            parser.FirstRowHasHeader = true;
            parser.FirstRowSetsExpectedColumnCount = true;
            return parser;
        }        
    }
}