namespace realbau_app.api.Models
{
    public class HausbegehungTermDB
    {
        public int? id { get; set; }
        public DateOnly? hbdate { get; set; }
        public TimeSpan? hbfrom { get; set; }
        public TimeSpan? hbto { get; set; }
        public int? busy { get; set; }
        public int? created_by { get; set; }
        public DateTime? created_on { get; set; }
    }
}
