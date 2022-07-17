using realbau_app.Models;

namespace realbau_app.Services.Interfaces
{
    public interface IHausbegehungService
    {
        public Task<IEnumerable<HausbegehungTerm>> HausbegehungTermsForDate(string city, string pop, int year, int month, int date);
    }
}
