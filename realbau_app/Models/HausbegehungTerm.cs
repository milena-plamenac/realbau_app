namespace realbau_app.Models
{
    public class HausbegehungTerm
    {
        public int? id { get; set; }
        public string? city { get; set; }
        public string? pop { get; set; }
        public DateOnly? hbdate { get; set; }
        public TimeSpan? hbfrom { get; set; }
        public TimeSpan? hbto { get; set; }
        public int? busy { get; set; }
        public int? created_by { get; set; }
        public DateTime? created_on { get; set; }
    }
}
