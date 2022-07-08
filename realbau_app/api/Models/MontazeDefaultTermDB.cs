namespace realbau_app.api.Models
{
    public class MontazeDefaultTermDB
    {
        public int? id { get; set; }
        public TimeSpan? mfrom { get; set; } 
        public TimeSpan? mto { get; set; }
        public int? created_by { get; set; }
        public DateTime? created_on { get; set; }

    }
}
