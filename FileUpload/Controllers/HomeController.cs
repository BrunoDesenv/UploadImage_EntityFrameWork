using FileUpload.Context;
using FileUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class HomeController : Controller
    {
        private ContextDataBase db = new ContextDataBase();

        // GET: Home
        public ActionResult Index()
        {
            //https://www.mikesdotnetting.com/article/259/asp-net-mvc-5-with-ef-6-working-with-files
            return View();
        }

        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file.ContentLength != 0)
            {
                var img = new UploadedImage
                {
                    FileName = System.IO.Path.GetFileName(file.FileName),
                    ContentType = file.ContentType,
                    File = new byte[file.ContentLength]
                };

                file.InputStream.Read(img.File, 0, file.ContentLength);

                db.UploadedImage.Add(img);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Show(int id)
        {
            var image = db.UploadedImage.Find(id);
            if (image != null)
            {
                return File(image.File, image.ContentType, "filename goes here");
            }

            return null;
        }
    }
}