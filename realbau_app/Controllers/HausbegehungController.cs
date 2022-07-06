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

        public IActionResult Terms(int address_id, string year, string month, string date)
        {
            List<HausbegehungTermDB> result = new List<HausbegehungTermDB>();
            bool doInsert = false;
            using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                con.Open();
                var cmd = new SqlCommand("select * from dbo.hausbegehung_term where hbdate = @hbdate", con);
                cmd.Parameters.AddWithValue("@hbdate", year + '-' + (Int32.Parse(month) + 1) + '-' + date);
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

                if (result.Count() == 0)
                {
                    reader.Close();
                    var cmd1 = new SqlCommand("select * from dbo.hausbegehung_default_term", con);
                    SqlDataReader reader1 = cmd1.ExecuteReader();

                    while (reader1.Read())
                    {
                        HausbegehungTermDB resultItem = new HausbegehungTermDB();
                        resultItem.id = Convert.IsDBNull(reader1["id"]) ? null : (int?)reader1["id"];
                        resultItem.hbdate = null; // Convert.IsDBNull(reader["hbdate"]) ? null : DateOnly.FromDateTime((DateTime)reader["hbdate"]);
                        resultItem.hbfrom = Convert.IsDBNull(reader1["hbfrom"]) ? null : (TimeSpan?)reader1["hbfrom"];
                        resultItem.hbto = Convert.IsDBNull(reader1["hbto"]) ? null : (TimeSpan?)reader1["hbto"];
                        resultItem.busy = 0; // Convert.IsDBNull(reader["busy"]) ? null : (int?)reader["busy"];
                        resultItem.created_by = Convert.IsDBNull(reader1["created_by"]) ? null : (int?)reader1["created_by"];
                        resultItem.created_on = Convert.IsDBNull(reader1["created_on"]) ? null : (DateTime?)reader1["created_on"];

                        result.Add(resultItem);

                        
                    }

                    doInsert = true;
                    reader1.Close();
                }

             
                if (doInsert)
                for(int i = 0; i<result.Count(); i++)
                {
                    HausbegehungTermDB resultItem = result[i];

                    String query = "insert into dbo.hausbegehung_term (hbdate, hbfrom, hbto, busy) values (@hbdate, @hbfrom, @hbto, @busy)";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@hbdate", (resultItem.hbdate == null) ? (year + '-' + (Int32.Parse(month) + 1) + '-' + date) : resultItem.hbdate);
                        command.Parameters.AddWithValue("@hbfrom", (resultItem.hbfrom == null) ? DBNull.Value : resultItem.hbfrom);
                        command.Parameters.AddWithValue("@hbto", (resultItem.hbto == null) ? DBNull.Value : resultItem.hbto);
                        command.Parameters.AddWithValue("@busy", (resultItem.busy == null) ? DBNull.Value : resultItem.busy);
                        //command.Parameters.AddWithValue("@created_by", null);
                        //command.Parameters.AddWithValue("@creted_on", null);


                        command.ExecuteNonQuery();

                    }
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
