using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace SqlClient_Contacts.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: UploadFile
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            try
            {
                //get file name
                var filename = Path.GetFileName(file.FileName);
                var fileNamePath = Path.Combine(Server.MapPath("~/Content/Uploads"),filename);
                file.SaveAs(fileNamePath);

                ViewBag.Message = "File uploaded correctly";
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.ToString();
            }

            return View();
        }
    }
}