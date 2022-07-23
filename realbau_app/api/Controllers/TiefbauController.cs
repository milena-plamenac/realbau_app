using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using realbau_app.api.Models;

namespace realbau_app.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiefbauController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("{address_id}")]
        public TiefbauDB Get(int address_id)
        {
            TiefbauDB result = new TiefbauDB();
            using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                con.Open();
                var cmd = new SqlCommand("select * from dbo.tiefbau where address_id = @address_id", con);
                cmd.Parameters.AddWithValue("@address_id", address_id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    result.id = Convert.IsDBNull(reader["id"]) ? null : (int?)reader["id"];
                    result.address_id = Convert.IsDBNull(reader["address_id"]) ? null : (int?)reader["address_id"];
                    result.tdate = Convert.IsDBNull(reader["tdate"]) ? null : (DateTime)reader["tdate"];
                    result.meter = Convert.IsDBNull(reader["meter"]) ? null : (int?)reader["meter"];
                    result.ready = Convert.IsDBNull(reader["ready"]) ? null : (int?)reader["ready"];
                    result.finished = Convert.IsDBNull(reader["finished"]) ? null : (int?)reader["finished"];
                    result.tcomment = Convert.IsDBNull(reader["tcomment"]) ? null : (string?)reader["tcomment"];
                    result.created_by = Convert.IsDBNull(reader["created_by"]) ? null : (int?)reader["created_by"];
                    result.created_on = Convert.IsDBNull(reader["created_on"]) ? null : (DateTime?)reader["created_on"];


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
        [HttpPost("{address_id}")]
        public void Post(int address_id, [FromBody] TiefbauDB tiefbau)
        {
            //HausbegehungDB hausbegehungDB = this.Get(address_id);
            using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                String query = "insert into dbo.tiefbau (address_id, tdate, meter, ready, finished, tcomment) values (@address_id, @tdate, @meter, @ready, @finished, @tcomment)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@address_id", address_id);
                    command.Parameters.AddWithValue("@tdate", (tiefbau.tdate == null) ? DBNull.Value : tiefbau.tdate);
                    command.Parameters.AddWithValue("@meter", (tiefbau.meter == null) ? DBNull.Value : tiefbau.meter);
                    command.Parameters.AddWithValue("@ready", (tiefbau.ready == null) ? DBNull.Value : tiefbau.ready);
                    command.Parameters.AddWithValue("@finished", (tiefbau.finished == null) ? DBNull.Value : tiefbau.finished);
                    command.Parameters.AddWithValue("@tcomment", (tiefbau.tcomment == null) ? DBNull.Value : tiefbau.tcomment);
                    //command.Parameters.AddWithValue("@created_by", null);
                    //command.Parameters.AddWithValue("@creted_on", null);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                }
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{address_id}")]
        public void Put(int address_id, [FromBody] TiefbauDB tiefbau)
        {
            TiefbauDB tiefbauDB = this.Get(address_id);
            using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                String query = "update dbo.tiefbau set tdate = @tdate, meter = @meter, ready = @ready, finished = @finished, tcomment = @tcomment where address_id = @address_id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tdate", (tiefbau.tdate == null) ? (tiefbauDB.tdate == null ? DBNull.Value : tiefbauDB.tdate) : tiefbau.tdate);
                    command.Parameters.AddWithValue("@meter", (tiefbau.meter == null) ? (tiefbauDB.meter == null ? DBNull.Value : tiefbauDB.meter) : tiefbau.meter);
                    command.Parameters.AddWithValue("@ready", (tiefbau.ready == null) ? (tiefbauDB.ready == null ? DBNull.Value : tiefbauDB.ready) : tiefbau.ready);
                    command.Parameters.AddWithValue("@finished", (tiefbau.finished == null) ? (tiefbauDB.finished == null ? DBNull.Value : tiefbauDB.finished) : tiefbau.finished);
                    command.Parameters.AddWithValue("@tcomment", (tiefbau.tcomment == null) ? (tiefbauDB.tcomment == null ? DBNull.Value : tiefbauDB.tcomment) : tiefbau.tcomment);
                    //command.Parameters.AddWithValue("@created_by", term.created_by);
                    //command.Parameters.AddWithValue("@creted_on", term.created_on);
                    command.Parameters.AddWithValue("@address_id", address_id);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                }
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{address_id}")]
        public void Delete(int address_id)
        {
            using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                String query = "delete from dbo.tiefbau where address_id = @address_id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@address_id", address_id);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                }
            }
        }
    }
}
