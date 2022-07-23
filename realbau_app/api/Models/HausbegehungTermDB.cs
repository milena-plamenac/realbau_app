namespace realbau_app.api.Models
{
    public class HausbegehungTermDB
    {
        public int id { get; set; }
        public string? city { get; set; }
        public string? pop { get; set; }
        public DateTime? hbdate { get; set; }
        public DateTime? hbfrom { get; set; }
        public DateTime? hbto { get; set; }
        public int? busy { get; set; }
        public int? created_by { get; set; }
        public DateTime? created_on { get; set; }
    }
}
