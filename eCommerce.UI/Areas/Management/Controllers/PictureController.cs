using eCommerce.Service.Pictutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Data.Domain.Entities;
using eCommerce.Common.ImgService;
using eCommerce.Dto.Picture;

namespace eCommerce.UI.Areas.Management.Controllers
{
    public class PictureController : Controller
    {
        PictureService _pictureService;
        public PictureController()
        {
            _pictureService = new PictureService();
        }
        [HttpPost]
        public ActionResult AsyncUpload()
        {
            HttpPostedFileBase file = Request.Files[0];
            if (file==null)
            {
                throw new Exception("No file Upload");
            }
            Picture _pic = new Picture();
            _pic.SmallPath = ImgUploadService.imgSingUpload(file, 200, 200);
            _pic.Default = ImgUploadService.imgDefaultSingUpload(file);
            if (_pictureService.Insert(_pic)!=null)
            {
                var result = new PictureViewModel();
                result.SmallPath = _pic.SmallPath;
                result.Id = _pic.Id;
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return Json("");
        }
    }
}