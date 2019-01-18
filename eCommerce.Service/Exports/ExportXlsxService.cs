using ClosedXML.Excel;
using eCommerce.Data.Domain.Entities;
using eCommerce.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Exports
{
    public class ExportXlsxService
    {
        private GenericUnitOfWork _unit;
        public ExportXlsxService()
        {
            _unit = new GenericUnitOfWork();
        }
        public DataTable CategoryExport()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[4] {
                new DataColumn("Id"),
                new DataColumn("Name"),
                new DataColumn("Phulished"),
                new DataColumn("OrderNo"),

            });
            var data = _unit.Repository<Category>().GetList();
            foreach (var item in data)
            {
                dt.Rows.Add(item.Id, item.Name, item.Published, item.OrderNo);
            }
            return dt;
        }
    }
}
