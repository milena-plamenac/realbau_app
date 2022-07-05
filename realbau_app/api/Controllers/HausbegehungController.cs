using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using realbau_app.api.Models;

namespace realbau_app.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HausbegehungController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("{address_id}")]
        public HausbegehungDB Get(int address_id)
        {
            HausbegehungDB result = new HausbegehungDB();
            using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                con.Open();
                var cmd = new SqlCommand("select * from dbo.hausbegehung where address_id = @address_id", con);
                cmd.Parameters.AddWithValue("@address_id", address_id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    result.id = Convert.IsDBNull(reader["id"]) ? null : (int?)reader["id"];
                    result.address_id = Convert.IsDBNull(reader["address_id"]) ? null : (int?)reader["address_id"];
                    result.hbdate = Convert.IsDBNull(reader["hbdate"]) ? null : (DateTime)reader["hbdate"];
                    result.hbfrom = Convert.IsDBNull(reader["hbfrom"]) ? null : (DateTime?)reader["hbfrom"];
                    result.hbto = Convert.IsDBNull(reader["hbto"]) ? null : (DateTime?)reader["hbto"];
                    result.calldate = Convert.IsDBNull(reader["calldate"]) ? null : (DateTime?)reader["calldate"];
                    result.finished = Convert.IsDBNull(reader["finished"]) ? null : (int?)reader["finished"];
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
        public void Post(int address_id, [FromBody] HausbegehungDB hausbegehung)
        {
            //HausbegehungDB hausbegehungDB = this.Get(address_id);
            using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                String query = "insert into dbo.hausbegehung (address_id, hbdate, hbfrom, hbto, calldate, finished) values (@address_id, @hbdate, @hbfrom, @hbto, @calldate, @finished)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@address_id", address_id);
                    command.Parameters.AddWithValue("@hbdate", (hausbegehung.hbdate == null) ? DBNull.Value : hausbegehung.hbdate);
                    command.Parameters.AddWithValue("@hbfrom", (hausbegehung.hbfrom == null) ? DBNull.Value : hausbegehung.hbfrom );
                    command.Parameters.AddWithValue("@hbto", (hausbegehung.hbto == null) ? DBNull.Value : hausbegehung.hbto);
                    command.Parameters.AddWithValue("@calldate", (hausbegehung.calldate == null) ? DBNull.Value : hausbegehung.calldate);
                    command.Parameters.AddWithValue("@finished", (hausbegehung.finished == null) ? DBNull.Value : hausbegehung.finished);
                    //command.Parameters.AddWithValue("@created_by", null);
                    //command.Parameters.AddWithValue("@creted_on", null);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                }
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{address_id}")]
        public void Put(int address_id, [FromBody] HausbegehungDB hausbegehung)
        {
            HausbegehungDB hausbegehungDB = this.Get(address_id);
            using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                String query = "update dbo.hausbegehung set hbdate = @hbdate, hbfrom = @hbfrom, hbto = @hbto, calldate = @calldate, finished = @finished where address_id = @address_id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@hbdate", (hausbegehung.hbdate == null) ? (hausbegehungDB.hbdate == null ? DBNull.Value : hausbegehungDB.hbdate) : hausbegehung.hbdate);
                    command.Parameters.AddWithValue("@hbfrom", (hausbegehung.hbfrom == null) ? (hausbegehungDB.hbfrom == null ? DBNull.Value : hausbegehungDB.hbfrom) : hausbegehung.hbfrom);
                    command.Parameters.AddWithValue("@hbto", (hausbegehung.hbto == null) ? (hausbegehungDB.hbto == null ? DBNull.Value : hausbegehungDB.hbto) : hausbegehung.hbto);
                    command.Parameters.AddWithValue("@calldate", (hausbegehung.calldate == null) ? (hausbegehungDB.calldate == null ? DBNull.Value : hausbegehungDB.calldate) : hausbegehung.calldate);
                    command.Parameters.AddWithValue("@finished", (hausbegehung.finished == null) ? (hausbegehungDB.finished == null ? DBNull.Value : hausbegehungDB.finished) : hausbegehung.finished);
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
                String query = "delete from dbo.hausbegehung where address_id = @address_id";

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
