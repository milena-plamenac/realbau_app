using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using realbau_app.Interfaces;

namespace realbau_app.Controllers
{
    public class StreamFileUploadController : Controller
    {
        readonly IStreamFileUploadService _streamFileUploadService;
        public StreamFileUploadController(IStreamFileUploadService streamFileUploadService)
        {
            _streamFileUploadService = streamFileUploadService;
        }
        [HttpGet]
        public IActionResult Index(string type, int address_id)
        {
            ViewBag.type = type;
            ViewBag.address_id = address_id;
            return View();
        }
        [ActionName("Index")]
        [HttpPost]
    
        public async Task<IActionResult> SaveFileToPhysicalFolder()
        {
            try
            {


                var boundary = HeaderUtilities.RemoveQuotes(
                    MediaTypeHeaderValue.Parse(Request.ContentType).Boundary
                ).Value;
                
                var reader = new MultipartReader(boundary, Request.Body);
                var section = await reader.ReadNextSectionAsync();
                string response = string.Empty;
                try
                {
                    if (await _streamFileUploadService.UploadFile(reader, section))
                    {
                        ViewBag.Message = "File Upload Successful";
                    }
                    else
                    {
                        ViewBag.Message = "File Upload Failed";
                    }
                }
                catch (Exception ex)
                {
                    //Log ex
                    ViewBag.Message = "File Upload Failed";
                }
         
                return View();
            }
            catch (Exception e)
            {
                var p = "In exception";
                return View();
            }
        }
    }
}
