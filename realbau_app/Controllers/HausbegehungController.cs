using Microsoft.AspNetCore.Mvc;
using realbau_app.api.Models;

namespace realbau_app.Controllers
{
    public class HausbegehungController : Controller
    {
        public IActionResult Index()
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
    }
}
