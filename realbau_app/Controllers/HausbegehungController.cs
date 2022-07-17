using Microsoft.AspNetCore.Mvc;
using realbau_app.api.Models;
using Microsoft.Data.SqlClient;
using realbau_app.Services.Interfaces;
using realbau_app.Models;

namespace realbau_app.Controllers
{
    public class HausbegehungController : Controller
    {
        private IHausbegehungService hausbegehungService;

        public HausbegehungController(IHausbegehungService hausbegehungService)
        {
            this.hausbegehungService = hausbegehungService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<HausbegehungTerm> terms = await this.hausbegehungService.HausbegehungTermsForDate("Eschweiler", "ewr-001", 2022, 5, 30);

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://localhost:7003/api/HausbegehungDefaultTerm");
            //    //HTTP GET
            //    var responseTask = client.GetAsync("");
            //    responseTask.Wait();

            //    var result = responseTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        var readTask = result.Content.ReadFromJsonAsync<IList<HausbegehungDefaultTermDB>>();
            //        readTask.Wait();

            //        terms = readTask.Result;
            //    }
            //    else //web api sent error response 
            //    {
            //        //log response status here..

            //        terms = Enumerable.Empty<HausbegehungDefaultTermDB>();

            //        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            //    }
            //}
            //return View(terms);

            return View(terms);
        }

        public IActionResult DefaultTerms()
        {
            IEnumerable<HausbegehungDefaultTermDB> terms = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7003/api/HausbegehungDefaultTerm");
                //HTTP GET
                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<HausbegehungDefaultTermDB>>();
                    readTask.Wait();

                    terms = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    terms = Enumerable.Empty<HausbegehungDefaultTermDB>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(terms);

            //return View();
        }

        public async Task<IActionResult> Terms()
        {
            

            return View();
        }

        public async Task<IActionResult> SearchTerms(string city, string pop, DateTime dateTime)
        {
            IEnumerable<HausbegehungTerm> terms = await this.hausbegehungService.HausbegehungTermsForDate(city, pop, dateTime.Year, dateTime.Month, dateTime.Day);
            return View("Terms", terms);
        }

    }
}
