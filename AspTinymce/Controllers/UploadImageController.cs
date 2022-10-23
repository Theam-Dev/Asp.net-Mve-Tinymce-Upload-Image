using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace AspTinymce.Controllers
{
    public class UploadImageController : ApiController
    {
       
        [HttpPost]
        public IHttpActionResult Upload()
        {
            var files = HttpContext.Current.Request.Files["file"];

            string fileName = Path.GetFileNameWithoutExtension(files.FileName);
            string extension = Path.GetExtension(files.FileName);

            string newFileName = fileName + "-" + DateTime.Now.ToString("yyyymmssffff") + extension;
            string UploadPath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Image/"), newFileName);
            var newpaht = new { location = Path.Combine("/Content/Image/", newFileName).Replace('\\', '/') };
            files.SaveAs(UploadPath);
            return Ok(newpaht);
        }
    }
}
