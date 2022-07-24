using realbau_app.Models;

namespace realbau_app.Services.Interfaces
{
    public interface IMontazeService
    {
        public Task<IEnumerable<MontazeTerm>> MontazeTermsForDate(string city, string pop, int year, int month, int date);
    }
}
