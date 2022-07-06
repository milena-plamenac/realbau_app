using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using realbau_app.api.Models;

namespace realbau_app.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaserController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("{address_id}")]
        public FaserDB Get(int address_id)
        {
            FaserDB result = new FaserDB();
            using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                con.Open();
                var cmd = new SqlCommand("select * from dbo.faser where address_id = @address_id", con);
                cmd.Parameters.AddWithValue("@address_id", address_id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    result.id = Convert.IsDBNull(reader["id"]) ? null : (int?)reader["id"];
                    result.address_id = Convert.IsDBNull(reader["address_id"]) ? null : (int?)reader["address_id"];
                    result.fdate = Convert.IsDBNull(reader["fdate"]) ? null : (DateTime)reader["fdate"];
                    result.finished = Convert.IsDBNull(reader["finished"]) ? null : (int?)reader["finished"];
                    result.fcomment = Convert.IsDBNull(reader["fcomment"]) ? null : (string?)reader["fcomment"];
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
        public void Post(int address_id, [FromBody] FaserDB faser)
        {
            //HausbegehungDB hausbegehungDB = this.Get(address_id);
            using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                String query = "insert into dbo.faser (address_id, fdate, finished, fcomment) values (@address_id, @fdate, @finished, @fcomment)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@address_id", address_id);
                    command.Parameters.AddWithValue("@fdate", (faser.fdate == null) ? DBNull.Value : faser.fdate);
                    command.Parameters.AddWithValue("@finished", (faser.finished == null) ? DBNull.Value : faser.finished);
                    command.Parameters.AddWithValue("@fcomment", (faser.fcomment == null) ? DBNull.Value : faser.fcomment);
                    //command.Parameters.AddWithValue("@created_by", null);
                    //command.Parameters.AddWithValue("@creted_on", null);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                }
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{address_id}")]
        public void Put(int address_id, [FromBody] FaserDB faser)
        {
            FaserDB faserDB = this.Get(address_id);
            using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                String query = "update dbo.faser set fdate = @fdate, finished = @finished, fcomment = @fcomment where address_id = @address_id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fdate", (faser.fdate == null) ? (faserDB.fdate == null ? DBNull.Value : faserDB.fdate) : faser.fdate);
                    command.Parameters.AddWithValue("@finished", (faser.finished == null) ? (faserDB.finished == null ? DBNull.Value : faserDB.finished) : faser.finished);
                    command.Parameters.AddWithValue("@fcomment", (faser.fcomment == null) ? (faserDB.fcomment == null ? DBNull.Value : faserDB.fcomment) : faser.fcomment);
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
                String query = "delete from dbo.faser where address_id = @address_id";

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
