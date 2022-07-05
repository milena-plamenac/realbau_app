using Microsoft.AspNetCore.Mvc;
using realbau_app.api.Models;
using realbau_app.Models;
using realbau_app.Models.Import;
using System.Diagnostics;

namespace realbau_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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