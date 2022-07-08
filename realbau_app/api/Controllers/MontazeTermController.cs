using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using realbau_app.api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace realbau_app.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MontazeTermController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("{mdate}")]
        public IEnumerable<MontazeTermDB> Get(string mdate)
        {
            List<MontazeTermDB> result = new List<MontazeTermDB>();
            using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                con.Open();
                var cmd = new SqlCommand("select * from dbo.montaze_term", con);
                    cmd.Parameters.AddWithValue("@mdate", mdate);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MontazeTermDB resultItem = new MontazeTermDB();
                    resultItem.id = Convert.IsDBNull(reader["id"]) ? null : (int?)reader["id"];
                    resultItem.mdate = Convert.IsDBNull(reader["mdate"]) ? null : DateOnly.FromDateTime((DateTime)reader["mdate"]); 
                    resultItem.mfrom = Convert.IsDBNull(reader["mfrom"]) ? null : (TimeSpan?)reader["mfrom"]; 
                    resultItem.mto = Convert.IsDBNull(reader["mto"]) ? null : (TimeSpan?)reader["mto"];
                    resultItem.busy = Convert.IsDBNull(reader["busy"]) ? null : (int?)reader["busy"];
                    resultItem.created_by = Convert.IsDBNull(reader["created_by"]) ? null : (int?)reader["created_by"]; 
                    resultItem.created_on = Convert.IsDBNull(reader["created_on"]) ? null : (DateTime?)reader["created_on"]; 

                    result.Add(resultItem);
                }

                if (result.Count() == 0)
                {
                    reader.Close();
                    var cmd1 = new SqlCommand("select * from dbo.montaze_default_term", con);
                    SqlDataReader reader1 = cmd1.ExecuteReader();

                    while (reader1.Read())
                    {
                        MontazeTermDB resultItem = new MontazeTermDB();
                        resultItem.id = Convert.IsDBNull(reader1["id"]) ? null : (int?)reader1["id"];
                        resultItem.mdate = null; // Convert.IsDBNull(reader["hbdate"]) ? null : DateOnly.FromDateTime((DateTime)reader["hbdate"]);
                        resultItem.mfrom = Convert.IsDBNull(reader1["mfrom"]) ? null : (TimeSpan?)reader1["mfrom"];
                        resultItem.mto = Convert.IsDBNull(reader1["mto"]) ? null : (TimeSpan?)reader1["mto"];
                        resultItem.busy = 0; // Convert.IsDBNull(reader["busy"]) ? null : (int?)reader["busy"];
                        resultItem.created_by = Convert.IsDBNull(reader1["created_by"]) ? null : (int?)reader1["created_by"];
                        resultItem.created_on = Convert.IsDBNull(reader1["created_on"]) ? null : (DateTime?)reader1["created_on"];

                        result.Add(resultItem);

                        this.Post(resultItem);
                    }
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
        public void Post([FromBody] MontazeTermDB term)
        {
            using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                String query = "insert into dbo.montaze_term (mdate, mfrom, mto, busy) values (@mdate, @mfrom, @mto, @busy)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mdate", (term.mdate == null) ? DBNull.Value : term.mdate);
                    command.Parameters.AddWithValue("@mfrom", (term.mfrom == null) ? DBNull.Value : term.mfrom);
                    command.Parameters.AddWithValue("@mto", (term.mto == null) ? DBNull.Value : term.mto);
                    command.Parameters.AddWithValue("@busy", (term.busy == null) ? DBNull.Value : term.busy);
                    //command.Parameters.AddWithValue("@created_by", null);
                    //command.Parameters.AddWithValue("@creted_on", null);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                }
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MontazeTermDB term)
        {
            using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                String query = "update dbo.montaze_term set mdate = @mdate, mfrom = @mfrom, mto = @mto, busy = @busy where id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mdate", (term.mdate == null) ? DBNull.Value : term.mdate);
                    command.Parameters.AddWithValue("@mfrom", (term.mfrom == null) ? DBNull.Value : term.mfrom);
                    command.Parameters.AddWithValue("@mto", (term.mto == null) ? DBNull.Value : term.mto);
                    command.Parameters.AddWithValue("@busy", (term.busy == null) ? DBNull.Value : term.busy);
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
                String query = "delete from dbo.montaze_term where id = @id";

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
