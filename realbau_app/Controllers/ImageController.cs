using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Mvc;
using System.Web;


namespace realbau_app.Controllers
{
    public class ImageController : Controller
    {
        public IActionResult Index()
        {
            return View();
            //string filePath = "C:\\Users\\lfili\\Downloads\\people-office.jpg";
            //try
            //{
            //    /* Load pre-authorized user credentials from the environment.
            //     TODO(developer) - See https://developers.google.com/identity for
            //     guides on implementing OAuth2 for your application. */
            //    //GoogleCredential credential = GoogleCredential.GetApplicationDefault()
            //    //    .CreateScoped(DriveService.Scope.Drive);

            //    ClientSecrets clientSecrets = new ClientSecrets
            //    {
            //        ClientId = "77157689726-8i51egb5sjeq4h4vjoj2t8ej47897tgi.apps.googleusercontent.com", // <- change
            //        ClientSecret = "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" // <- change
            //    };

            //    /* set where to save access token. The token stores the user's access and refresh tokens, and is created automatically when the authorization flow completes for the first time. */
            //    string tokenPath = "C:\\Users\\lfili\\Desktop"; // <- change

            //    string[] scopes = { DriveService.Scope.Drive };

            //    UserCredential authorizedUserCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            //      clientSecrets,
            //      scopes,
            //      "user",
            //      CancellationToken.None,
            //      new FileDataStore(tokenPath, true)
            //    ).Result;

            //    // Create Drive API service.
            //    var service = new DriveService(new BaseClientService.Initializer
            //    {
            //        HttpClientInitializer = authorizedUserCredential, //credential,
            //        ApplicationName = "Drive API Snippets"
            //    });

            //    // Upload file photo.jpg on drive.
            //    var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            //    {
            //        Name = "photo.jpg"
            //    };
            //    FilesResource.CreateMediaUpload request;
            //    // Create a new file on drive.
            //    using (var stream = new FileStream(filePath,
            //               FileMode.Open))
            //    {
            //        // Create a new file, with metadata and stream.
            //        request = service.Files.Create(
            //            fileMetadata, stream, "image/jpeg");
            //        request.Fields = "id";
            //        request.Upload();
            //    }

            //    var file = request.ResponseBody;
            //    // Prints the uploaded file id.
            //    Console.WriteLine("File ID: " + file.Id);
            //    return View("File found! Id: " + file.Id);
            //}
            //catch (Exception e)
            //{
            //    // TODO(developer) - handle error appropriately
            //    if (e is AggregateException)
            //    {
            //        Console.WriteLine("Credential Not found");
            //    }
            //    else if (e is FileNotFoundException)
            //    {
            //        Console.WriteLine("File not found");
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            //return View("File not found");


        }

        //[HttpPost]
        //public ActionResult UploadFile(HttpPostedFileBase file)
        //{
        //    try
        //    {
        //        if (file.ContentLength > 0)
        //        {
        //            string _FileName = Path.GetFileName(file.FileName);
        //            string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
        //            file.SaveAs(_path);
        //        }
        //        ViewBag.Message = "File Uploaded Successfully!!";
        //        return View();
        //    }
        //    catch
        //    {
        //        ViewBag.Message = "File upload failed!!";
        //        return View();
        //    }
        //}
    }
}
