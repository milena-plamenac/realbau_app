
using realbau_app.Utilities.Converters;
using System.Text.Json.Serialization;

namespace realbau_app.api.Models
{
    public class HausbegehungDB
    {
        public int? id { get; set; }
        public int? address_id { get; set; }


        public DateTime? hbdate { get; set; }
        public DateTime? hbfrom { get; set; }
        public DateTime? hbto { get; set; }
        public DateTime? calldate { get; set; }
        public int? finished { get; set; }
        public int? created_by { get; set; }
        public DateTime? created_on { get; set; }
    }
}
