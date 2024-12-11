using eShopLegacyMVC.Services;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.IO;


namespace eShopLegacyMVC.Controllers
{
    public class DocumentsController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            var files = FileService.Create().ListFiles();
            return View(files);
        }

        [ResponseCache(VaryByQueryKeys = new[] { "filename" }, Duration = int.MaxValue)]
        public FileResult Download(string filename)
        {
            var fileService = FileService.Create();
            var file = fileService.DownloadFile(filename);
            FileContentResult fc = new FileContentResult(file, GetMimeType(filename));
            fc.FileDownloadName = filename;
            return fc;
        }

        private string GetMimeType(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            return extension switch
            {
                ".txt" => MediaTypeNames.Text.Plain,
                ".pdf" => MediaTypeNames.Application.Pdf,
                ".jpg" or ".jpeg" => MediaTypeNames.Image.Jpeg,
                ".gif" => MediaTypeNames.Image.Gif,
                ".png" => "image/png",
                _ => MediaTypeNames.Application.Octet
            };
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadDocument()
        {
            var fileService = FileService.Create();
            fileService.UploadFile(Request.Files);
            return RedirectToAction("Index");
        }
    }
}