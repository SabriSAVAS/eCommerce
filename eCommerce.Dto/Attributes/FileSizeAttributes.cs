using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerce.Dto.Attributes
{
    public class FileSizeAttributes : ValidationAttribute
    {
        private int _maxSize;
        private int _TotalSize;
        public FileSizeAttributes(int Size)
        {
            _maxSize = Size;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var files = value as HttpPostedFileBase;
                if (files.ContentLength > 0)
                {
                    _maxSize = _maxSize * 1024 * 1024;
                    _TotalSize = files.ContentLength;
                    if (_TotalSize < _maxSize)
                    {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult(ErrorMessage = "İzin verilen boyuttan fazla resim secildi");

                }

            }
            return ValidationResult.Success;

        }
    }
}