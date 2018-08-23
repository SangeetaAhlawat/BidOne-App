using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BidOneSampleApp.Models;
using System.Web.UI;

namespace BidOneSampleApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult submitForm([System.Web.Http.FromBody]FormData model)
        {            
            if (ModelState.IsValid)
            {
                if (model.firstName != null && model.lastName != null)
                {
                    try
                    {
                        var javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                        string jsonString = javaScriptSerializer.Serialize(model);

                        string fileLocation = System.Configuration.ConfigurationManager.AppSettings["fileLocation"];
                        string fileName = System.Configuration.ConfigurationManager.AppSettings["fileName"];
                        string filePath = fileLocation + "\\" + fileName;

                        if (!System.IO.Directory.Exists(fileLocation))
                        {
                            System.IO.Directory.CreateDirectory(fileLocation);
                        }

                        System.IO.File.WriteAllText(filePath, jsonString);
                    }
                    catch (Exception ex)
                    {
                        throw ex;  // TODO: can write this error in log file.
                    }
                }
            }
            return Json("Write successfully", JsonRequestBehavior.AllowGet); 
        }
    }
}
