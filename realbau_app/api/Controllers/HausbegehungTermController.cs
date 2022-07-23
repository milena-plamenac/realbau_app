using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using realbau_app.api.Models;
using realbau_app.api.Repositories.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace realbau_app.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HausbegehungTermController : ControllerBase
    {
        private IHausbegehungTermRepository hausbegehungTermRepository;
        public HausbegehungTermController(IHausbegehungTermRepository hausbegehungTermRepository)
        {
            this.hausbegehungTermRepository = hausbegehungTermRepository;
        }

        [HttpGet("{city}/{pop}/{year}/{month}/{date}")]
        public async Task<IEnumerable<HausbegehungTermDB>> Get(string city, string pop, int year, int month, int date)
        {
            return await this.hausbegehungTermRepository.HausbegehungTermsForDate(city, pop, year, month, date);  
            //List<HausbegehungTermDB> result = new List<HausbegehungTermDB>();
            //using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            //{
            //    con.Open();
            //    var cmd = new SqlCommand("select * from dbo.hausbegehung_term", con);
            //        cmd.Parameters.AddWithValue("@hbdate", hbdate);
            //    SqlDataReader reader = cmd.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        HausbegehungTermDB resultItem = new HausbegehungTermDB();
            //        resultItem.id = Convert.IsDBNull(reader["id"]) ? null : (int?)reader["id"];
            //        resultItem.hbdate = Convert.IsDBNull(reader["hbdate"]) ? null : DateOnly.FromDateTime((DateTime)reader["hbdate"]); 
            //        resultItem.hbfrom = Convert.IsDBNull(reader["hbfrom"]) ? null : (TimeSpan?)reader["hbfrom"]; 
            //        resultItem.hbto = Convert.IsDBNull(reader["hbto"]) ? null : (TimeSpan?)reader["hbto"];
            //        resultItem.busy = Convert.IsDBNull(reader["busy"]) ? null : (int?)reader["busy"];
            //        resultItem.created_by = Convert.IsDBNull(reader["created_by"]) ? null : (int?)reader["created_by"]; 
            //        resultItem.created_on = Convert.IsDBNull(reader["created_on"]) ? null : (DateTime?)reader["created_on"]; 

            //        result.Add(resultItem);
            //    }

            //    if (result.Count() == 0)
            //    {
            //        reader.Close();
            //        var cmd1 = new SqlCommand("select * from dbo.hausbegehung_default_term", con);
            //        SqlDataReader reader1 = cmd1.ExecuteReader();

            //        while (reader1.Read())
            //        {
            //            HausbegehungTermDB resultItem = new HausbegehungTermDB();
            //            resultItem.id = Convert.IsDBNull(reader1["id"]) ? null : (int?)reader1["id"];
            //            resultItem.hbdate = null; // Convert.IsDBNull(reader["hbdate"]) ? null : DateOnly.FromDateTime((DateTime)reader["hbdate"]);
            //            resultItem.hbfrom = Convert.IsDBNull(reader1["hbfrom"]) ? null : (TimeSpan?)reader1["hbfrom"];
            //            resultItem.hbto = Convert.IsDBNull(reader1["hbto"]) ? null : (TimeSpan?)reader1["hbto"];
            //            resultItem.busy = 0; // Convert.IsDBNull(reader["busy"]) ? null : (int?)reader["busy"];
            //            resultItem.created_by = Convert.IsDBNull(reader1["created_by"]) ? null : (int?)reader1["created_by"];
            //            resultItem.created_on = Convert.IsDBNull(reader1["created_on"]) ? null : (DateTime?)reader1["created_on"];

            //            result.Add(resultItem);

            //            this.Post(resultItem);
            //        }
            //    }
            //}

            //return result;
        }


        [HttpPost]
        public async Task<HausbegehungTermDB> Post([FromBody] HausbegehungTermDB term)
        {
            return await this.hausbegehungTermRepository.Insert(term);
        }

        [HttpPut("{id}")]
        public async Task<int> Put(int id, [FromBody] HausbegehungTermDB term)
        {
            return await this.hausbegehungTermRepository.Update(id, term);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            return await this.hausbegehungTermRepository.Delete(id);
        }
    }
}
