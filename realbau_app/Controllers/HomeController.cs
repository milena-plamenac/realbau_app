using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using realbau_app.api.Models;
using realbau_app.Models;
using realbau_app.Models.Import;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace realbau_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddressDetails(int id, int test)
        {
            var message = "Hello ";

            AddressDetails addressDetails = new AddressDetails();
            //var exists = 0;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7003/api/Address/" + id);
                //HTTP GET


                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var result = responseTask.Result;
                var readResult = result.Content.ReadFromJsonAsync<AddressDetails>();
                readResult.Wait();

                addressDetails = readResult.Result;

            }

            // open xml sdk - docx
            using (MemoryStream mem = new MemoryStream())
            {
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(mem, DocumentFormat.OpenXml.WordprocessingDocumentType.Document, true))
                {
                    wordDoc.AddMainDocumentPart();
                    // siga a ordem
                    DocumentFormat.OpenXml.Wordprocessing.Document doc = new DocumentFormat.OpenXml.Wordprocessing.Document();
                    Body body = new Body();

                    // 1 paragrafo
                    Paragraph para = new Paragraph();

                    ParagraphProperties paragraphProperties1 = new ParagraphProperties();
                    ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId() { Val = "Normal" };
                    Justification justification1 = new Justification() { Val = JustificationValues.Center };
                    ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();

                    paragraphProperties1.Append(paragraphStyleId1);
                    paragraphProperties1.Append(justification1);
                    paragraphProperties1.Append(paragraphMarkRunProperties1);

                    Run run = new Run();
                    RunProperties runProperties1 = new RunProperties();

                    Text text = new Text() { Text = "Address report" };

                    // siga a ordem 
                    run.Append(runProperties1);
                    run.Append(text);
                    run.Append(new Break());
                    run.Append(new Text() { Text = addressDetails.city + ", " + addressDetails.street + ", " + addressDetails.housenumber });
                    run.Append(new Break());
                    run.Append(new Text() { Text = addressDetails.name });
                    para.Append(paragraphProperties1);
                    para.Append(run);

                    // 2 paragrafo
                    Paragraph para2 = new Paragraph();

                    ParagraphProperties paragraphProperties2 = new ParagraphProperties();
                    ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "Normal" };
                    Justification justification2 = new Justification() { Val = JustificationValues.Start };
                    ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();

                    paragraphProperties2.Append(paragraphStyleId2);
                    paragraphProperties2.Append(justification2);
                    paragraphProperties2.Append(paragraphMarkRunProperties2);

                    Run run2 = new Run();
                    RunProperties runProperties3 = new RunProperties();
                    Text text2 = new Text();
                    text2.Text = "Teste aqui";

                    run2.AppendChild(new Break());
                    run2.AppendChild(new Text(){ Text = "Hausbegehung"});
                    run2.AppendChild(new Break());
                    run2.AppendChild(new Text("Termin: " + addressDetails.hbfrom + "-" + addressDetails.hbto));
                    run2.AppendChild(new Text("Comment: " + addressDetails.hbcomment));
                    run2.AppendChild(new Break());
                    run2.AppendChild(new Break());
                    run2.AppendChild(new Text() { Text = "Tiefbau" });
                    run2.AppendChild(new Break());
                    run2.AppendChild(new Text("Comment: " + addressDetails.tcomment));
                    run2.AppendChild(new Break());
                    run2.AppendChild(new Break());
                    run2.AppendChild(new Text() { Text = "Faser" });
                    run2.AppendChild(new Break());
                    run2.AppendChild(new Text("Comment: " + addressDetails.fcomment));
                    run2.AppendChild(new Break());
                    run2.AppendChild(new Break());
                    run2.AppendChild(new Text() { Text = "Montaze" });
                    run2.AppendChild(new Break());
                    run2.AppendChild(new Text("Termin: " + addressDetails.mfrom + "-" + addressDetails.mto));
                    run2.AppendChild(new Text("Comment: " + addressDetails.mcomment));
                    run2.AppendChild(new Break());
                    run2.AppendChild(new Break());
                    run2.AppendChild(new Text() { Text = "Aktivirung" });
                    run2.AppendChild(new Break());
                    run2.AppendChild(new Text("Comment: " + addressDetails.acomment));
                    run2.AppendChild(new Break());
                    run2.AppendChild(new Break());
                    run2.AppendChild(new Text() { Text = "Vermessung" });
                    run2.AppendChild(new Break());
                    run2.AppendChild(new Text("Comment: " + addressDetails.vcomment));

                    para2.Append(paragraphProperties2);
                    para2.Append(run2);



                    // todos os 2 paragrafos no main body
                    body.Append(para);
                    body.Append(para2);

                    doc.Append(body);

                    wordDoc.MainDocumentPart.Document = doc;

                    wordDoc.Close();
                }
                return File(mem.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "ABC.docx");
            }
        }

        public IActionResult Index()
        {


            IEnumerable<AddressDB> addresses = null;
            var exists = 0;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7003/api/Address/");
                //HTTP GET


                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var result = responseTask.Result;
                var readResult = result.Content.ReadFromJsonAsync<IEnumerable<AddressDB>>();
                readResult.Wait();

                addresses = readResult.Result;

            }


            return View(addresses);



        }

        [HttpPost]
        public IActionResult Filter(Filter filter)
        {
            IEnumerable<AddressDB> addresses = null;

            return View("Index", addresses);
        }


            [HttpGet]
        public IActionResult AddressDetails(int id)
        {
            //IEnumerable<AddressDB> addresses = null;
            AddressDetails addressDetails = new AddressDetails();
            //var exists = 0;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7003/api/Address/" + id);
                //HTTP GET


                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var result = responseTask.Result;
                var readResult = result.Content.ReadFromJsonAsync<AddressDetails>();
                readResult.Wait();

                addressDetails = readResult.Result;

            }


            return View(addressDetails);

        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Addresses(NewAddress newAddress)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}