using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using realbau_app.api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace realbau_app.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MontazeDefaultTermController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<MontazeDefaultTermDB> Get()
        {
            List<MontazeDefaultTermDB> result = new List<MontazeDefaultTermDB>();
            using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                con.Open();
                var cmd = new SqlCommand("select * from dbo.montaze_default_term", con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MontazeDefaultTermDB resultItem = new MontazeDefaultTermDB();
                    resultItem.id = Convert.IsDBNull(reader["id"]) ? null : (int?)reader["id"]; ;
                    resultItem.mfrom = Convert.IsDBNull(reader["mfrom"]) ? null : (TimeSpan?)reader["mfrom"]; ;
                    resultItem.mto = Convert.IsDBNull(reader["mto"]) ? null : (TimeSpan?)reader["mto"]; ;
                    resultItem.created_by = Convert.IsDBNull(reader["created_by"]) ? null : (int?)reader["created_by"]; ;
                    resultItem.created_on = Convert.IsDBNull(reader["created_on"]) ? null : (DateTime?)reader["created_on"]; ;

                    result.Add(resultItem);
                }
            }

            return result;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] MontazeDefaultTermDB term)
        {
            using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                String query = "insert into dbo.montaze_default_term (mfrom, mto) values (@mfrom, @mto)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mfrom", (term.mfrom == null) ? DBNull.Value : term.mfrom);
                    command.Parameters.AddWithValue("@mto", (term.mto == null) ? DBNull.Value : term.mto);
                    //command.Parameters.AddWithValue("@created_by", null);
                    //command.Parameters.AddWithValue("@creted_on", null);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                }
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MontazeDefaultTermDB term)
        {
            using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                String query = "update dbo.montaze_default_term set mfrom = @mfrom, mto = @mto where id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mfrom", (term.mfrom == null) ? DBNull.Value : term.mfrom);
                    command.Parameters.AddWithValue("@mto", (term.mto == null) ? DBNull.Value : term.mto);
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
                String query = "delete from dbo.montaze_default_term where id = @id";

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
