using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultasHistoricas.Application.Abstractions
{
    public interface IExcelExportService
    {
        Task<byte[]> ExportDataSQL(string name);

        Task<byte[]> ExportDataOracle(string name);
    }
}
