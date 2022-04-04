using VehicleLoan.DataAccessLayer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace VehicleLoanAPI.Controllers 
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IdentityDocumentsController : ControllerBase
    {
        [Obsolete]
        public IHostingEnvironment hostingEnvironment;
        public VehicleloanContext dbContext;

        [Obsolete]
        public IdentityDocumentsController(IHostingEnvironment hostingEnv, VehicleloanContext db)
        {
            hostingEnvironment = hostingEnv;
            dbContext = db;
        }
        [HttpPost]
        [Obsolete]
        public ActionResult<string> UploadImages()
        { 
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        FileInfo f = new FileInfo(file.FileName);
                        var newfilename = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + f.Extension;
                        var path = Path.Combine("", hostingEnvironment.ContentRootPath + "\\images\\" + newfilename);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        IdentityDocuments imageUpload = new IdentityDocuments();
                        imageUpload.Imagepath = path;
                        imageUpload.InsertedOn = DateTime.Now;
                        dbContext.IdentityDocuments.Add(imageUpload);
                        dbContext.SaveChanges();
                    }
                    return "Saved Successfully";
                }
                else
                {
                    return "select Files";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpGet]
        public ActionResult<List<IdentityDocuments>> GetImageUpload()
        {
            var result = dbContext.IdentityDocuments.ToList();
            return result;
        }
    }
}