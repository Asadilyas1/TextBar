using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using TaxBarAssociation.Areas.Identity.Data;
using TaxBarAssociation.Models;
using System.Linq;
using System.IO;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TaxBarAssociation.Controllers
{
    public class ReferenceDocumentController : Controller
    {

        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ReferenceDocumentController(AppDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context=context;
            _hostEnvironment=hostEnvironment;
        }


        public IActionResult GetPdf(int id)
        {
            var getPdf = _context.ReferenceDocuments.Where(x => x.Id == id).Select(x => x.DocumentName).FirstOrDefault();

            var memory = DownloadFile(getPdf,"wwwroot\\PDF");

            return File(memory.ToArray(), "application/pdf",getPdf);
        }

        private MemoryStream DownloadFile(string filname, string uploadpath)     
        {

            var path = Path.Combine(Directory.GetCurrentDirectory(), uploadpath, filname);
            var memery = new MemoryStream();
            if (System.IO.File.Exists(path))
            {
                var net = new System.Net.WebClient();
                var data = net.DownloadData(path);
                var content = new System.IO.MemoryStream(data);
                memery = content;
            }
            memery.Position = 0;
            return memery;
        }

        public IActionResult Index()
        {

            var show = _context.ReferenceDocuments.ToList();
            return View(show);
        }

        public IActionResult AddDocument()
        {
            List<int> years = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                years.Add(DateTime.Now.AddYears(-i).Year);
            }
            ViewBag.Years = years;
           
            return View();
        }

        [HttpPost]
        public IActionResult AddDocument(IFormFile file, int year, [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            
            if(file == null || year == 0)
            {
                List<int> years = new List<int>();
                for (int i = 0; i < 5; i++)
                {
                    years.Add(DateTime.Now.AddYears(-i).Year);
                }
                ViewBag.Years = years;

                ModelState.AddModelError("Both", "File upload");
               
                return View(file);
            }

            string filename = $"{webHostEnvironment.WebRootPath}\\PDF\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(filename))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            ReferenceDocument document = new ReferenceDocument();
            document.DocumentName = file.FileName;
            document.DocumentYear = year;
            _context.ReferenceDocuments.Add(document);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



       public IActionResult EditDocument(int id)
       {
            var getDate = _context.ReferenceDocuments.Find(id);

          

            List<int> years = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                years.Add(DateTime.Now.AddYears(-i).Year);
            }
          
            ViewBag.Years = years;
            return View(getDate);
       }



        [HttpPost]
        public IActionResult EditDocument(IFormFile file, int year, [FromServices] IWebHostEnvironment webHostEnvironment , ReferenceDocument referenceDocument)
        {

            if(file==null)
            {
                ReferenceDocument document = new ReferenceDocument();
                 var years= document.DocumentYear =year;
                referenceDocument.DocumentYear = years;
                _context.ReferenceDocuments.Update(referenceDocument);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                string filename = $"{webHostEnvironment.WebRootPath}\\PDF\\{file.FileName}";
                using (FileStream fileStream = System.IO.File.Create(filename))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
                if (referenceDocument.DocumentName != null)
                {
                    string filePath = Path.Combine(webHostEnvironment.WebRootPath, "PDF", referenceDocument.DocumentName);
                    System.IO.File.Delete(filePath);
                }
                 ReferenceDocument document = new ReferenceDocument();
                 referenceDocument.DocumentName= document.DocumentName = file.FileName;
                 referenceDocument.DocumentYear=  document.DocumentYear =year;
                _context.ReferenceDocuments.Update(referenceDocument);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
           
        }

        //public IActionResult AlertDelete(int id)
        //{
        //    if (id > 0)
        //    { 
        //        var getData = _context.ReferenceDocuments.Find(id);
        //        getData.DocumentName = " ";
        //        _context.ReferenceDocuments.Update(getData);
        //        _context.SaveChanges();

        //        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "PDF", getData.DocumentName);
        //        System.IO.File.Delete(filePath);
        //        return Json(true);
        //    }
           
        //    return Json(false);
        //}


        
    }
}
