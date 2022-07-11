namespace realbau_app.api.Models
{
    public class VermessungDB
    {
        public int? id { get; set; }
        public int? address_id { get; set; }


        public DateTime? vdate { get; set; }
        public int? finished { get; set; }
        public string? vcomment { get; set; }
        public int? created_by { get; set; }
        public DateTime? created_on { get; set; }
    }
}
