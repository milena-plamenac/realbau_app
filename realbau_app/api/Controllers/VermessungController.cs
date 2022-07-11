using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using realbau_app.api.Models;

namespace realbau_app.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VermessungController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("{address_id}")]
        public VermessungDB Get(int address_id)
        {
            VermessungDB result = new VermessungDB();
            using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                con.Open();
                var cmd = new SqlCommand("select * from dbo.vermessung where address_id = @address_id", con);
                cmd.Parameters.AddWithValue("@address_id", address_id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    result.id = Convert.IsDBNull(reader["id"]) ? null : (int?)reader["id"];
                    result.address_id = Convert.IsDBNull(reader["address_id"]) ? null : (int?)reader["address_id"];
                    result.vdate = Convert.IsDBNull(reader["vdate"]) ? null : (DateTime)reader["vdate"];
                    result.finished = Convert.IsDBNull(reader["finished"]) ? null : (int?)reader["finished"];
                    result.vcomment = Convert.IsDBNull(reader["vcomment"]) ? null : (string?)reader["vcomment"];
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
        public void Post(int address_id, [FromBody] VermessungDB vermessung)
        {
            //HausbegehungDB hausbegehungDB = this.Get(address_id);
            using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                String query = "insert into dbo.vermessung (address_id, vdate, finished, vcomment) values (@address_id, @vdate, @finished, @vcomment)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@address_id", address_id);
                    command.Parameters.AddWithValue("@vdate", (vermessung.vdate == null) ? DBNull.Value : vermessung.vdate);
                    command.Parameters.AddWithValue("@finished", (vermessung.finished == null) ? DBNull.Value : vermessung.finished);
                    command.Parameters.AddWithValue("@vcomment", (vermessung.vcomment == null) ? DBNull.Value : vermessung.vcomment);
                    //command.Parameters.AddWithValue("@created_by", null);
                    //command.Parameters.AddWithValue("@creted_on", null);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                }
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{address_id}")]
        public void Put(int address_id, [FromBody] VermessungDB vermessung)
        {
            VermessungDB vermessungDB = this.Get(address_id);
            using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                String query = "update dbo.vermessung set vdate = @vdate, finished = @finished, vcomment = @vcomment where address_id = @address_id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@vdate", (vermessung.vdate == null) ? (vermessungDB.vdate == null ? DBNull.Value : vermessungDB.vdate) : vermessung.vdate);
                    command.Parameters.AddWithValue("@finished", (vermessung.finished == null) ? (vermessungDB.finished == null ? DBNull.Value : vermessungDB.finished) : vermessung.finished);
                    command.Parameters.AddWithValue("@vcomment", (vermessung.vcomment == null) ? (vermessungDB.vcomment == null ? DBNull.Value : vermessungDB.vcomment) : vermessung.vcomment);
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
                String query = "delete from dbo.vermessung where address_id = @address_id";

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
