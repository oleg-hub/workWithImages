using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp111.Models;

namespace WebApp111.Controllers
{
    public class HomeController : Controller
    {
        ModelModel m = new ModelModel();
        public ActionResult Index()
        {
            return View(m);
        }

        public PartialViewResult PartialV()
        {

            //ModelModel m = new ModelModel();
            //HttpPostedFileBase model = null;
            //var length = model.InputStream.Length;
            //byte[] fileData = null;
            //using (var binaryReader = new BinaryReader(model.InputStream))
            //{
            //    fileData = binaryReader.ReadBytes(model.ContentLength);
            //}
            //m.TopBar = fileData;

            return PartialView(m);
        }

        [HttpPost]
        public ActionResult Index(/*int type,*/ HttpPostedFileBase model)
        {

            ModelModel m = new ModelModel();

            if (model != null)
            {
                var length = model.InputStream.Length;
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(model.InputStream))
                {
                    fileData = binaryReader.ReadBytes(model.ContentLength);
                }
                m.TopBar = fileData;
            }

            return View(m);
        }

        [HttpPost]
        
        public ActionResult SaveUserSignature(int id, HttpPostedFileBase signatureFile,string file)
        {
            return Json(new { success = false});
        }

    }
}