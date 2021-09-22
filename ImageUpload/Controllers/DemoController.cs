using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ImageUpload.Models;

namespace ImageUpload.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ImageUpload.Models.ImageUpload up , HttpPostedFileBase file)
        {
            using (Image_UploadDB db = new Image_UploadDB())
            {
                ImageUpload.Models.ImageUpload ups = new Models.ImageUpload();

                if (file != null && file.ContentLength > 0)
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/Images"),
                                                   Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        ups.StudentName = up.StudentName;
                        ups.Image_path = path;

                        db.ImageUploads.Add(ups);

                        db.SaveChanges();
                        ViewBag.Message = "File uploaded successfully";

                        ModelState.Clear();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                else
                {
                    ViewBag.Message = "You have not specified a file.";
                }
                return View();


            }
        }

        [HttpGet]
        public ActionResult UploadImages()
        {

            return View();
        }

        [HttpPost]
        [ActionName("Upload")]
        public ActionResult UploadImage()
        {
           
            if (Request.Files.Count != 0)
            {

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    var fileName = Path.GetFileName(file.FileName);

                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    file.SaveAs(path);
                }

            }
            return RedirectToAction("UploadImages");
        }
    }
}