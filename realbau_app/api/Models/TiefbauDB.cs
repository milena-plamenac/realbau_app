
using realbau_app.Utilities.Converters;
using System.Text.Json.Serialization;

namespace realbau_app.api.Models
{
    public class TiefbauDB
    {
        public int? id { get; set; }
        public int? address_id { get; set; }


        public DateTime? tdate { get; set; }
        public int? meter { get; set; }
        public int? ready { get; set; }
        public int? finished { get; set; }
        public string? tcomment { get; set; }
        public int? created_by { get; set; }
        public DateTime? created_on { get; set; }
    }
}
