using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace eCommerce.DTO.Attributes
{
    public class FileExtentionAttributes : ValidationAttribute
    {
        private List<string> _Allowextention;
        public FileExtentionAttributes(string extention)
        {
            _Allowextention = extention.Split(';').ToList();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value != null)
            {
                var item = value as HttpPostedFileBase;

                if (_Allowextention.Contains(Path.GetExtension(item.FileName)))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(ErrorMessage = "Istenilen dosya türü değil");
                }

            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}

