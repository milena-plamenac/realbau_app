using realbau_app.api.Models;

namespace realbau_app.api.Repositories.Interfaces
{
    public interface IHausbegehungRepository
    {
        public Task<IEnumerable<HausbegehungTermDB>> HausbegehungTermsForDate(string city, string pop, int year, int month,int date);

        public Task Insert(HausbegehungTermDB term); 
    }
}
