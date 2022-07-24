namespace realbau_app.Models
{
    public class MontazeTerm
    {
        public int? id { get; set; }
        public string? city { get; set; }
        public string? pop { get; set; }
        public DateTime? mdate { get; set; }
        public DateTime? mfrom { get; set; }
        public DateTime? mto { get; set; }
        public int? busy { get; set; }
        public int? created_by { get; set; }
        public DateTime? created_on { get; set; }
    }
}

