using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using realbau_app.api.Models;

namespace realbau_app.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MontazeController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("{address_id}")]
        public MontazeDB Get(int address_id)
        {
            MontazeDB result = new MontazeDB();
            using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                con.Open();
                var cmd = new SqlCommand("select * from dbo.montaze where address_id = @address_id", con);
                cmd.Parameters.AddWithValue("@address_id", address_id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    result.id = Convert.IsDBNull(reader["id"]) ? null : (int?)reader["id"];
                    result.address_id = Convert.IsDBNull(reader["address_id"]) ? null : (int?)reader["address_id"];
                    result.mdate = Convert.IsDBNull(reader["mdate"]) ? null : (DateTime)reader["mdate"];
                    result.mfrom = Convert.IsDBNull(reader["mfrom"]) ? null : (DateTime?)reader["mfrom"];
                    result.mto = Convert.IsDBNull(reader["mto"]) ? null : (DateTime?)reader["mto"];
                    result.calldate = Convert.IsDBNull(reader["calldate"]) ? null : (DateTime?)reader["calldate"];
                    result.finished = Convert.IsDBNull(reader["finished"]) ? null : (int?)reader["finished"];
                    result.mcomment = Convert.IsDBNull(reader["mcomment"]) ? null : (string?)reader["mcomment"];
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
        public void Post(int address_id, [FromBody] MontazeDB montaze)
        {
            //HausbegehungDB hausbegehungDB = this.Get(address_id);
            using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                String query = "insert into dbo.montaze (address_id, mdate, mfrom, mto, calldate, finished, mcomment) values (@address_id, @mdate, @mfrom, @mto, @calldate, @finished, @mcomment)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@address_id", address_id);
                    command.Parameters.AddWithValue("@mdate", (montaze.mdate == null) ? DBNull.Value : montaze.mdate);
                    command.Parameters.AddWithValue("@mfrom", (montaze.mfrom == null) ? DBNull.Value : montaze.mfrom );
                    command.Parameters.AddWithValue("@mto", (montaze.mto == null) ? DBNull.Value : montaze.mto);
                    command.Parameters.AddWithValue("@calldate", (montaze.calldate == null) ? DBNull.Value : montaze.calldate);
                    command.Parameters.AddWithValue("@finished", (montaze.finished == null) ? DBNull.Value : montaze.finished);
                    command.Parameters.AddWithValue("@mcomment", (montaze.mcomment == null) ? DBNull.Value : montaze.mcomment);
                    //command.Parameters.AddWithValue("@created_by", null);
                    //command.Parameters.AddWithValue("@creted_on", null);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                }
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{address_id}")]
        public void Put(int address_id, [FromBody] MontazeDB montaze)
        {
            MontazeDB montazeDB = this.Get(address_id);
            using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                String query = "update dbo.montaze set mdate = @mdate, mfrom = @mfrom, mto = @mto, calldate = @calldate, finished = @finished, mcomment = @mcomment where address_id = @address_id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mdate", (montaze.mdate == null) ? (montazeDB.mdate == null ? DBNull.Value : montazeDB.mdate) : montaze.mdate);
                    command.Parameters.AddWithValue("@mfrom", (montaze.mfrom == null) ? (montazeDB.mfrom == null ? DBNull.Value : montazeDB.mfrom) : montaze.mfrom);
                    command.Parameters.AddWithValue("@mto", (montaze.mto == null) ? (montazeDB.mto == null ? DBNull.Value : montazeDB.mto) : montaze.mto);
                    command.Parameters.AddWithValue("@calldate", (montaze.calldate == null) ? (montazeDB.calldate == null ? DBNull.Value : montazeDB.calldate) : montaze.calldate);
                    command.Parameters.AddWithValue("@finished", (montaze.finished == null) ? (montazeDB.finished == null ? DBNull.Value : montazeDB.finished) : montaze.finished);
                    command.Parameters.AddWithValue("@mcomment", (montaze.mcomment == null) ? (montazeDB.mcomment == null ? DBNull.Value : montazeDB.mcomment) : montaze.mcomment);
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
                String query = "delete from dbo.montaze where address_id = @address_id";

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
