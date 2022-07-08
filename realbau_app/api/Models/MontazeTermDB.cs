namespace realbau_app.api.Models
{
    public class MontazeTermDB
    {
        public int? id { get; set; }
        public DateOnly? mdate { get; set; }
        public TimeSpan? mfrom { get; set; }
        public TimeSpan? mto { get; set; }
        public int? busy { get; set; }
        public int? created_by { get; set; }
        public DateTime? created_on { get; set; }
    }
}
