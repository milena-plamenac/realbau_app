using Microsoft.AspNetCore.Mvc;
using realbau_app.api.Models;
using Microsoft.Data.SqlClient;

namespace realbau_app.Controllers
{
    public class HausbegehungController : Controller
    {
        public IActionResult Index()
        {
            //IEnumerable<HausbegehungDefaultTermDB> terms = null;

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

            return View();
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

        public IActionResult Terms(int address_id)
        {
            List<HausbegehungTermDB> result = new List<HausbegehungTermDB>();
            using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                con.Open();
                var cmd = new SqlCommand("select * from dbo.hausbegehung_term", con);
                cmd.Parameters.AddWithValue("@hbdate", "2022-06-30");
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    HausbegehungTermDB resultItem = new HausbegehungTermDB();
                    resultItem.id = Convert.IsDBNull(reader["id"]) ? null : (int?)reader["id"];
                    resultItem.hbdate = Convert.IsDBNull(reader["hbdate"]) ? null : DateOnly.FromDateTime((DateTime)reader["hbdate"]);
                    resultItem.hbfrom = Convert.IsDBNull(reader["hbfrom"]) ? null : (TimeSpan?)reader["hbfrom"];
                    resultItem.hbto = Convert.IsDBNull(reader["hbto"]) ? null : (TimeSpan?)reader["hbto"];
                    resultItem.busy = Convert.IsDBNull(reader["busy"]) ? null : (int?)reader["busy"];
                    resultItem.created_by = Convert.IsDBNull(reader["created_by"]) ? null : (int?)reader["created_by"];
                    resultItem.created_on = Convert.IsDBNull(reader["created_on"]) ? null : (DateTime?)reader["created_on"];

                    result.Add(resultItem);
                }
            }

            //IEnumerable<HausbegehungTermDB> terms = null;

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://localhost:7003/api/HausbegehungTerm/" + DateTime.Now.ToString("yyyy-MM-dd"));
            //    //HTTP GET
            //    var responseTask = client.GetAsync("");
            //    responseTask.Wait();

            //    var result = responseTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        var readTask = result.Content.ReadFromJsonAsync<IList<HausbegehungTermDB>>();
            //        readTask.Wait();

            //        terms = readTask.Result;
            //    }
            //    else //web api sent error response 
            //    {
            //        //log response status here..

            //        terms = Enumerable.Empty<HausbegehungTermDB>();

            //        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            //    }
            //}
            //return View(terms);

            return View(result);
        }
    }
}
