using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace eCommerce.Dto.Enums
{
    public class Enums
    {

       public enum Vat
        {
            KdvYok=0,
            Vat1 = 1,
            Vat8 = 8,
            Vat18=18,
            Vat24=24
           
        }
        public static List<SelectListItem> VatList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "Kdv Yok", Value = "0,00" });
            list.Add(new SelectListItem { Text = "% 1", Value = "1,00" });
            list.Add(new SelectListItem { Text = "% 8", Value = "8,00" });
            list.Add(new SelectListItem { Text = "% 18", Value = "18,00" });
            list.Add(new SelectListItem { Text = "% 24", Value = "24,00" });
            return list.OrderBy(x=>x.Value).ToList();
        }
    }
}
