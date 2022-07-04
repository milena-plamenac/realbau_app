using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using realbau_app.api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace realbau_app.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HausbegehungTermController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("{hbdate}")]
        public IEnumerable<HausbegehungTermDB> Get(string hbdate)
        {
            List<HausbegehungTermDB> result = new List<HausbegehungTermDB>();
            using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                con.Open();
                var cmd = new SqlCommand("select * from dbo.hausbegehung_term", con);
                    cmd.Parameters.AddWithValue("@hbdate", hbdate);
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

            return result;
        }

        // GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] HausbegehungTermDB term)
        {
            using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                String query = "insert into dbo.hausbegehung_term (hbdate, hbfrom, hbto, busy) values (@hbdate, @hbfrom, @hbto, @busy)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@hbdate", term.hbdate);
                    command.Parameters.AddWithValue("@hbfrom", term.hbfrom);
                    command.Parameters.AddWithValue("@hbto", term.hbto);
                    command.Parameters.AddWithValue("@busy", term.busy);
                    //command.Parameters.AddWithValue("@created_by", null);
                    //command.Parameters.AddWithValue("@creted_on", null);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                }
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] HausbegehungTermDB term)
        {
            using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                String query = "update dbo.hausbegehung_term set hbdate = @hbdate, hbfrom = @hbfrom, hbto = @hbto, busy = @busy where id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@hbdate", term.hbdate);
                    command.Parameters.AddWithValue("@hbfrom", term.hbfrom);
                    command.Parameters.AddWithValue("@hbto", term.hbto);
                    command.Parameters.AddWithValue("@busy", term.busy);
                    //command.Parameters.AddWithValue("@created_by", term.created_by);
                    //command.Parameters.AddWithValue("@creted_on", term.created_on);
                    command.Parameters.AddWithValue("@id", term.id);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                }
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                String query = "delete from dbo.hausbegehung_term where id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                }
            }
        }
    }
}
