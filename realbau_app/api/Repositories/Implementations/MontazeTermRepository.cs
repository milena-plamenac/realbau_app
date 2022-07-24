using Microsoft.Data.SqlClient;
using realbau_app.api.Models;
using realbau_app.api.Repositories.Interfaces;

namespace realbau_app.api.Repositories.Implementations
{
    public class MontazeTermRepository: IMontazeTermRepository
    {

        public async Task<IEnumerable<MontazeTermDB>> MontazeTermsForDate(string city, string pop, int year, int month, int date)
        {
            try
            {
                List<MontazeTermDB> result = new List<MontazeTermDB>();
                // bool doInsert = false;
                using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from dbo.montaze_term where city = @city and pop = @pop and mdate = @mdate order by Datepart(hour, mfrom)", con);
                    cmd.Parameters.AddWithValue("@mdate", year.ToString() + '-' + month.ToString() + '-' + date.ToString());
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@pop", pop);
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        MontazeTermDB resultItem = new MontazeTermDB();
                        resultItem.id = (int)reader["id"];
                        resultItem.mdate = Convert.IsDBNull(reader["mdate"]) ? null : (DateTime?)reader["mdate"];
                        resultItem.mfrom = Convert.IsDBNull(reader["mfrom"]) ? null : (DateTime?)reader["mfrom"];
                        resultItem.mto = Convert.IsDBNull(reader["mto"]) ? null : (DateTime?)reader["mto"];
                        resultItem.busy = Convert.IsDBNull(reader["busy"]) ? null : (int?)reader["busy"];
                        resultItem.created_by = Convert.IsDBNull(reader["created_by"]) ? null : (int?)reader["created_by"];
                        resultItem.created_on = Convert.IsDBNull(reader["created_on"]) ? null : (DateTime?)reader["created_on"];
                        resultItem.city = Convert.IsDBNull(reader["city"]) ? null : (string?)reader["city"];
                        resultItem.pop = Convert.IsDBNull(reader["pop"]) ? null : (string?)reader["pop"];

                        result.Add(resultItem);
                    }
                  
                }
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<MontazeTermDB> GetById(int id)
        {
            try
            {
                MontazeTermDB result = new MontazeTermDB();
                using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from dbo.montaze_term where id = @id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        result.id = (int)reader["id"];
                        result.mdate = Convert.IsDBNull(reader["mdate"]) ? null : (DateTime)reader["mdate"];
                        result.mfrom = Convert.IsDBNull(reader["mfrom"]) ? null : (DateTime?)reader["mfrom"];
                        result.mto = Convert.IsDBNull(reader["mto"]) ? null : (DateTime?)reader["mto"];
                        result.busy = Convert.IsDBNull(reader["busy"]) ? null : (int?)reader["busy"];
                        result.created_by = Convert.IsDBNull(reader["created_by"]) ? null : (int?)reader["created_by"];
                        result.created_on = Convert.IsDBNull(reader["created_on"]) ? null : (DateTime?)reader["created_on"];
                    }
                }

                return result;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<MontazeTermDB> Insert(MontazeTermDB term)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
                {
                    String query = "insert into dbo.montaze_term (city, pop, mdate, mfrom, mto, busy)  OUTPUT INSERTED.[ID] values (@city, @pop, @mdate, @mfrom, @mto, @busy)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@city", (term.city == null) ? DBNull.Value : term.city);
                        command.Parameters.AddWithValue("@pop", (term.pop == null) ? DBNull.Value : term.pop);
                        command.Parameters.AddWithValue("@mdate", (term.mdate == null) ? DBNull.Value : term.mdate);
                        command.Parameters.AddWithValue("@mfrom", (term.mfrom == null) ? DBNull.Value : term.mfrom);
                        command.Parameters.AddWithValue("@mto", (term.mto == null) ? DBNull.Value : term.mto);
                        command.Parameters.AddWithValue("@busy", (term.busy == null) ? 0 : term.busy);
                        //command.Parameters.AddWithValue("@created_by", null);
                        //command.Parameters.AddWithValue("@creted_on", null);

                        connection.Open();
                        int result = (int)await command.ExecuteScalarAsync();

                        return new MontazeTermDB()
                        {
                            city = term.city,
                            pop = term.pop,
                            mdate = term.mdate,
                            mfrom = term.mfrom,
                            mto = term.mto,
                            busy = term.busy,
                            id = result
                        };
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<int> Update(int id, MontazeTermDB term)
        {
            try
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
                        int result = await command.ExecuteNonQueryAsync();

                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
                {
                    String query = "delete from dbo.montaze_term where id = @id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@id", id);

                        connection.Open();
                        int result = await command.ExecuteNonQueryAsync();

                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                return -1;
            }
        }

    }
}
