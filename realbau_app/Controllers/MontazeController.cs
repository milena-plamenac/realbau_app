using Microsoft.AspNetCore.Mvc;
using realbau_app.api.Models;
using Microsoft.Data.SqlClient;
using realbau_app.Models;
using realbau_app.Services.Interfaces;

namespace realbau_app.Controllers
{
    public class MontazeController : Controller
    {
        private IMontazeService montazeService;
        private IAddressService addressService;

        public MontazeController(IMontazeService montazeService, IAddressService addressService)
        {
            this.montazeService = montazeService;
            this.addressService = addressService;
        }
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
            IEnumerable<MontazeDefaultTermDB> terms = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7003/api/MontazeDefaultTerm");
                //HTTP GET
                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<MontazeDefaultTermDB>>();
                    readTask.Wait();

                    terms = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    terms = Enumerable.Empty<MontazeDefaultTermDB>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(terms);

            //return View();
        }

        //int address_id, string year, string month, string date
        public IActionResult Terms()
        {
            return View();
            //List<MontazeTermDB> result = new List<MontazeTermDB>();
            //bool doInsert = false;
            //using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            //{
            //    con.Open();
            //    var cmd = new SqlCommand("select * from dbo.montaze_term where mdate = @mdate", con);
            //    cmd.Parameters.AddWithValue("@mdate", year + '-' + (Int32.Parse(month) + 1) + '-' + date);
            //    SqlDataReader reader = cmd.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        MontazeTermDB resultItem = new MontazeTermDB();
            //        resultItem.id = Convert.IsDBNull(reader["id"]) ? null : (int?)reader["id"];
            //        resultItem.mdate = Convert.IsDBNull(reader["mdate"]) ? null : DateOnly.FromDateTime((DateTime)reader["mdate"]);
            //        resultItem.mfrom = Convert.IsDBNull(reader["mfrom"]) ? null : (TimeSpan?)reader["mfrom"];
            //        resultItem.mto = Convert.IsDBNull(reader["mto"]) ? null : (TimeSpan?)reader["mto"];
            //        resultItem.busy = Convert.IsDBNull(reader["busy"]) ? null : (int?)reader["busy"];
            //        resultItem.created_by = Convert.IsDBNull(reader["created_by"]) ? null : (int?)reader["created_by"];
            //        resultItem.created_on = Convert.IsDBNull(reader["created_on"]) ? null : (DateTime?)reader["created_on"];

            //        result.Add(resultItem);
            //    }

            //    if (result.Count() == 0)
            //    {
            //        reader.Close();
            //        var cmd1 = new SqlCommand("select * from dbo.montaze_default_term", con);
            //        SqlDataReader reader1 = cmd1.ExecuteReader();

            //        while (reader1.Read())
            //        {
            //            MontazeTermDB resultItem = new MontazeTermDB();
            //            resultItem.id = Convert.IsDBNull(reader1["id"]) ? null : (int?)reader1["id"];
            //            resultItem.mdate = null; // Convert.IsDBNull(reader["hbdate"]) ? null : DateOnly.FromDateTime((DateTime)reader["hbdate"]);
            //            resultItem.mfrom = Convert.IsDBNull(reader1["mfrom"]) ? null : (TimeSpan?)reader1["mfrom"];
            //            resultItem.mto = Convert.IsDBNull(reader1["mto"]) ? null : (TimeSpan?)reader1["mto"];
            //            resultItem.busy = 0; // Convert.IsDBNull(reader["busy"]) ? null : (int?)reader["busy"];
            //            resultItem.created_by = Convert.IsDBNull(reader1["created_by"]) ? null : (int?)reader1["created_by"];
            //            resultItem.created_on = Convert.IsDBNull(reader1["created_on"]) ? null : (DateTime?)reader1["created_on"];

            //            result.Add(resultItem);

                        
            //        }

            //        doInsert = true;
            //        reader1.Close();
            //    }

             
            //    if (doInsert)
            //    for(int i = 0; i<result.Count(); i++)
            //    {
            //        MontazeTermDB resultItem = result[i];

            //        String query = "insert into dbo.montaze_term (mdate, mfrom, mto, busy) values (@mdate, @mfrom, @mto, @busy)";

            //        using (SqlCommand command = new SqlCommand(query, con))
            //        {
            //            command.Parameters.AddWithValue("@mdate", (resultItem.mdate == null) ? (year + '-' + (Int32.Parse(month) + 1) + '-' + date) : resultItem.mdate);
            //            command.Parameters.AddWithValue("@mfrom", (resultItem.mfrom == null) ? DBNull.Value : resultItem.mfrom);
            //            command.Parameters.AddWithValue("@mto", (resultItem.mto == null) ? DBNull.Value : resultItem.mto);
            //            command.Parameters.AddWithValue("@busy", (resultItem.busy == null) ? DBNull.Value : resultItem.busy);
            //            //command.Parameters.AddWithValue("@created_by", null);
            //            //command.Parameters.AddWithValue("@creted_on", null);


            //            command.ExecuteNonQuery();

            //        }
            //    }
            //}

            

            ////IEnumerable<HausbegehungTermDB> terms = null;

            ////using (var client = new HttpClient())
            ////{
            ////    client.BaseAddress = new Uri("https://localhost:7003/api/HausbegehungTerm/" + DateTime.Now.ToString("yyyy-MM-dd"));
            ////    //HTTP GET
            ////    var responseTask = client.GetAsync("");
            ////    responseTask.Wait();

            ////    var result = responseTask.Result;
            ////    if (result.IsSuccessStatusCode)
            ////    {
            ////        var readTask = result.Content.ReadFromJsonAsync<IList<HausbegehungTermDB>>();
            ////        readTask.Wait();

            ////        terms = readTask.Result;
            ////    }
            ////    else //web api sent error response 
            ////    {
            ////        //log response status here..

            ////        terms = Enumerable.Empty<HausbegehungTermDB>();

            ////        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            ////    }
            ////}
            ////return View(terms);

            //return View(result);
        }

        public async Task<IActionResult> SearchTerms(string city, string pop, DateTime dateTime)
        {
            IEnumerable<MontazeTerm> terms = await this.montazeService.MontazeTermsForDate(city, pop, dateTime.Year, dateTime.Month, dateTime.Day);
            return View("Terms", terms);
        }

        public async Task<IActionResult> Reserve(int id) // there is going to be guid
        {
            Models.AddressDetails addressDetails = await this.addressService.GetAddressById(id);
            return View(addressDetails);
        }
    }
}
