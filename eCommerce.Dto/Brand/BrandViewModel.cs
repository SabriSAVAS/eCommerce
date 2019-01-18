using eCommerce.DTO.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eCommerce.Dto.Brand
{
    public class BrandViewModel
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen bir isim girin.")]
        public string Name { get; set; }

        public string Seo { get; set; }
        public string Description { get; set; }
        [FileExtentionAttributes(".jpg;.png")]
        public HttpPostedFileBase Picture { get; set; }
        public string PicturePath { get; set; }
        public int? PictureId { get; set; }
        public int OrderNo { get; set; }
        public int CreatedById
        {
            get; set;
        }
        public DateTime CreatedDate
        {
            get; set;
        }
        public int? UpdatedById
        {
            get; set;
        }
        public DateTime? UpdatedDate
        {
            get; set;
        }
    }
}
