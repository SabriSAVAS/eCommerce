using System;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web;
using d = System.Drawing;

namespace eCommerce.Common.ImgService
{
    public class ImgUploadService
    {
        /// <summary>
        /// resmi yeniden boyutlandır.
        /// </summary>
        /// <param name="imgToResize">boyutlandırılacak resim</param>
        /// <param name="size">boyutlar</param>
        /// <returns>Image titipnde bir resim</returns>
        public static d.Image ResizeImage(d.Image imgToResize, d.Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            d.Bitmap b = new d.Bitmap(destWidth, destHeight);
            d.Graphics g = d.Graphics.FromImage((d.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            imgToResize.Dispose();

            return (d.Image)b;
        }

        /// <summary>
        /// Resmi farklı boyutlarda kaydeder.
        /// </summary>
        /// <param name="image">Boyutlandırılacak resim.</param>
        /// <param name="size">Resim boyutu.</param>
        /// <param name="directory">Resmin kaydedileceği dizin.</param>
        /// <param name="fileName">Resim adı.</param>
        public static void SaveResizedImage(d.Image image, d.Size size, string directory, string fileName)
        {
            d.Image _image = ResizeImage(image, size);
            _image.Save(Path.Combine(directory, fileName));
            _image.Dispose();
        }
        public static string imgDefaultSingUpload(HttpPostedFileBase file)
        {
            if (file == null) return "";
            if (file.ContentLength > 0)
            {
                if (file.ContentType.Contains("image"))
                {
                    d.Image orjImg = d.Image.FromStream(file.InputStream);
                    string UniqImg = Guid.NewGuid() + Path.GetFileNameWithoutExtension(file.FileName) + Path.GetExtension(file.FileName);


                    d.Bitmap defaultpicture = new d.Bitmap(orjImg);


                    string defaultPath = HttpContext.Current.Server.MapPath("~/Content/images/thumbs/DefaultPath/" + UniqImg);
                    string xpath = "/Content/images/thumbs/DefaultPath/" + UniqImg;
                    defaultpicture.Save(defaultPath);
                    return xpath;
                }


            }
            return "";


        }
        public static string imgSingUpload(HttpPostedFileBase file, int widht, int height)
        {
            if (file == null) return "";
            if (file.ContentLength > 0)
            {
                if (file.ContentType.Contains("image"))
                {
                    d.Image orjImg = d.Image.FromStream(file.InputStream);
                    string UniqImg = Guid.NewGuid() + Path.GetFileNameWithoutExtension(file.FileName) + Path.GetExtension(file.FileName);

                    d.Bitmap smallpicture = new d.Bitmap(orjImg);


                    string smallPath = HttpContext.Current.Server.MapPath("~/Content/images/thumbs/SmbPath/" + UniqImg);
                    string xPath = "/Content/images/thumbs/SmbPath/" + UniqImg;
                    smallpicture.Save(smallPath);

                    var imageDirectory = HttpContext.Current.Server.MapPath("~/Content/images/thumbs/SmbPath");
                    SaveResizedImage(d.Image.FromFile(Path.Combine(imageDirectory, UniqImg)), new d.Size(widht, height), imageDirectory, UniqImg);

                    return xPath;
                }


            }
            return "";


        }
    }
}