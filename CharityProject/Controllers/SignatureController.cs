using CharityProject.Database;
using CharityProject.Entities.SignatureClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CharityProject.Controllers
{
    public class SignatureController : Controller
    {
         private CharityDBContext db;


        //Constructor
        public SignatureController(CharityDBContext context)
        {
            db = context;
        }




        // GET: Signature
        public async Task<ActionResult> UploadSignature(string imageData)
        {
            var signature = new Signature() { ImageData = imageData };
            db.Signatures.Add(signature);
            await db.SaveChangesAsync();

            string fileNameWitPath = DateTime.Now.ToString().Replace("/", "").Replace(" ", " ").Replace(":", "") + ".png";
            string path = Path.Combine(Server.MapPath("~/SignatureImages/"), fileNameWitPath);

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {

                    byte[] data = Convert.FromBase64String(imageData);

                    bw.Write(data);
                    bw.Close();
                }
            }

            return RedirectToAction("About", "Home");
        }



        public JsonResult GetSignatures()
        {

            var signatures = db.Signatures.Count();

            return Json(signatures, JsonRequestBehavior.AllowGet);

        }




    }
}