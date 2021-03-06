using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageUpload.Models;
namespace ImageUpload.Controllers
{
    public class JqueryImageController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult ImageUpload(ImageUpload.Models.ImageUpload model)
        {
        
            Image_UploadDB db = new Image_UploadDB();
          

            var file = model.fileName;
            var fileNames=Path.GetFileName(file.FileName);
            var fileExtenstion = Path.GetExtension(file.FileName);

            
                if (file != null)
                {
                // modifty server path on 22-09-2021
                    file.SaveAs(Server.MapPath("~/Images/" + file.FileName));
                    ImageUpload.Models.ImageUpload img = new ImageUpload.Models.ImageUpload();
                    img.StudentName = file.FileName;
                    img.Image_path = "~/Images/" + file.FileName;
                    db.ImageUploads.Add(img);
                    db.SaveChanges();
                }
      
            return Json(file.FileName, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ImageRetriver(string name)
        {
            Image_UploadDB db = new Image_UploadDB();

            var path = db.ImageUploads.Where(x => x.Image_path == name);
            
            return Json(path, JsonRequestBehavior.AllowGet);
        }

    }
}