using Microsoft.Data.SqlClient;
using realbau_app.api.Models;
using realbau_app.api.Repositories.Interfaces;

namespace realbau_app.api.Repositories.Implementations
{
    public class HausbegehungRepository : IHausbegehungRepository
    {
        public async Task<IEnumerable<HausbegehungTermDB>> HausbegehungTermsForDate(string city, string pop, int year, int month, int date)
        {
            try
            {
                List<HausbegehungTermDB> result = new List<HausbegehungTermDB>();
                // bool doInsert = false;
                using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from dbo.hausbegehung_term where city = @city and pop = @pop and hbdate = @hbdate order by Datepart(hour, hbfrom)", con);
                    cmd.Parameters.AddWithValue("@hbdate", year.ToString() + '-' + month.ToString() + '-' + date.ToString());
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@pop", pop);
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        HausbegehungTermDB resultItem = new HausbegehungTermDB();
                        resultItem.id = Convert.IsDBNull(reader["id"]) ? null : (int?)reader["id"];
                        resultItem.hbdate = Convert.IsDBNull(reader["hbdate"]) ? null : (DateTime?)reader["hbdate"];
                        resultItem.hbfrom = Convert.IsDBNull(reader["hbfrom"]) ? null : (DateTime?)reader["hbfrom"];
                        resultItem.hbto = Convert.IsDBNull(reader["hbto"]) ? null : (DateTime?)reader["hbto"];
                        resultItem.busy = Convert.IsDBNull(reader["busy"]) ? null : (int?)reader["busy"];
                        resultItem.created_by = Convert.IsDBNull(reader["created_by"]) ? null : (int?)reader["created_by"];
                        resultItem.created_on = Convert.IsDBNull(reader["created_on"]) ? null : (DateTime?)reader["created_on"];

                        result.Add(resultItem);
                    }

                    //if (result.Count() == 0)
                    //{
                    //    reader.Close();
                    //    var cmd1 = new SqlCommand("select * from dbo.hausbegehung_default_term", con);
                    //    SqlDataReader reader1 = cmd1.ExecuteReader();

                    //    while (reader1.Read())
                    //    {
                    //        HausbegehungTermDB resultItem = new HausbegehungTermDB();
                    //        resultItem.id = Convert.IsDBNull(reader1["id"]) ? null : (int?)reader1["id"];
                    //        resultItem.hbdate = null; // Convert.IsDBNull(reader["hbdate"]) ? null : DateOnly.FromDateTime((DateTime)reader["hbdate"]);
                    //        resultItem.hbfrom = Convert.IsDBNull(reader1["hbfrom"]) ? null : (TimeSpan?)reader1["hbfrom"];
                    //        resultItem.hbto = Convert.IsDBNull(reader1["hbto"]) ? null : (TimeSpan?)reader1["hbto"];
                    //        resultItem.busy = 0; // Convert.IsDBNull(reader["busy"]) ? null : (int?)reader["busy"];
                    //        resultItem.created_by = Convert.IsDBNull(reader1["created_by"]) ? null : (int?)reader1["created_by"];
                    //        resultItem.created_on = Convert.IsDBNull(reader1["created_on"]) ? null : (DateTime?)reader1["created_on"];

                    //        result.Add(resultItem);


                    //    }

                    //    doInsert = true;
                    //    reader1.Close();
                    //}


                    //if (doInsert)
                    //    for (int i = 0; i < result.Count(); i++)
                    //    {
                    //        HausbegehungTermDB resultItem = result[i];

                    //        String query = "insert into dbo.hausbegehung_term (hbdate, hbfrom, hbto, busy) values (@hbdate, @hbfrom, @hbto, @busy)";

                    //        using (SqlCommand command = new SqlCommand(query, con))
                    //        {
                    //            command.Parameters.AddWithValue("@hbdate", (resultItem.hbdate == null) ? (year + '-' + (Int32.Parse(month) + 1) + '-' + date) : resultItem.hbdate);
                    //            command.Parameters.AddWithValue("@hbfrom", (resultItem.hbfrom == null) ? DBNull.Value : resultItem.hbfrom);
                    //            command.Parameters.AddWithValue("@hbto", (resultItem.hbto == null) ? DBNull.Value : resultItem.hbto);
                    //            command.Parameters.AddWithValue("@busy", (resultItem.busy == null) ? DBNull.Value : resultItem.busy);
                    //            //command.Parameters.AddWithValue("@created_by", null);
                    //            //command.Parameters.AddWithValue("@creted_on", null);


                    //            command.ExecuteNonQuery();

                    //        }
                    //    }
                }
                return result;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public async Task<HausbegehungTermDB> Insert(HausbegehungTermDB term)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
                {
                    String query = "insert into dbo.hausbegehung_term (city, pop, hbdate, hbfrom, hbto, busy)  OUTPUT INSERTED.[ID] values (@city, @pop, @hbdate, @hbfrom, @hbto, @busy)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@city", (term.city == null) ? DBNull.Value : term.city);
                        command.Parameters.AddWithValue("@pop", (term.pop == null) ? DBNull.Value : term.pop);
                        command.Parameters.AddWithValue("@hbdate", (term.hbdate == null) ? DBNull.Value : term.hbdate);
                        command.Parameters.AddWithValue("@hbfrom", (term.hbfrom == null) ? DBNull.Value : term.hbfrom);
                        command.Parameters.AddWithValue("@hbto", (term.hbto == null) ? DBNull.Value : term.hbto);
                        command.Parameters.AddWithValue("@busy", (term.busy == null) ? 0 : term.busy);
                        //command.Parameters.AddWithValue("@created_by", null);
                        //command.Parameters.AddWithValue("@creted_on", null);

                        connection.Open();
                        int result = (int)await command.ExecuteScalarAsync();
                 
                        return new HausbegehungTermDB()
                        {
                            city = term.city,
                            pop = term.pop,
                            hbdate = term.hbdate,
                            hbfrom = term.hbfrom,
                            hbto = term.hbto,
                            busy = term.busy,
                            id = result   
                        };
                    }
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
