
using realbau_app.Utilities.Converters;
using System.Text.Json.Serialization;

namespace realbau_app.api.Models
{
    public class MontazeDB
    {
        public int? id { get; set; }
        public int? address_id { get; set; }


        public DateTime? mdate { get; set; }
        public DateTime? mfrom { get; set; }
        public DateTime? mto { get; set; }
        public DateTime? calldate { get; set; }
        public int? finished { get; set; }
        public string? mcomment { get; set; }
        public int? created_by { get; set; }
        public DateTime? created_on { get; set; }
    }
}
