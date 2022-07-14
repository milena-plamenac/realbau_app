using realbau_app.api.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace realbau_app.api.Repositories.Implementations
{
    public class ImageRepository : IImageRepository
    {
        public async Task<bool> Save(string type, int address_id, string name)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
                {
                    String query = "insert into dbo.image (image_type, address_id, name) values (@image_type, @address_id, @name)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@image_type", type);
                        command.Parameters.AddWithValue("@address_id", address_id);
                        command.Parameters.AddWithValue("@name", name);
                        //command.Parameters.AddWithValue("@created_by", null);
                        //command.Parameters.AddWithValue("@creted_on", null);

                        connection.Open();
                        int result = await command.ExecuteNonQueryAsync();

                        return result > 0;

                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
