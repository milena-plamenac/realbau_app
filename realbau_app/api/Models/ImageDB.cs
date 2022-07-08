namespace realbau_app.api.Models
{
    public class ImageDB
    {
        public int id { get; set; }
        public string image_type { get; set; }
        public int address_id   { get; set; }
        public string name { get; set; }
        public int? created_by { get; set; }
        public DateTime? created_on { get; set; }

    }
}
