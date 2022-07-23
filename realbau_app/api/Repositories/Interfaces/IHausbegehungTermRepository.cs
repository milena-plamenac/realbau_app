using realbau_app.api.Models;

namespace realbau_app.api.Repositories.Interfaces
{
    public interface IHausbegehungTermRepository
    {
        public Task<IEnumerable<HausbegehungTermDB>> HausbegehungTermsForDate(string city, string pop, int year, int month,int date);

        public Task<HausbegehungTermDB> GetById(int id);

        public Task<HausbegehungTermDB> Insert(HausbegehungTermDB term); 

        public Task<int> Update(int id, HausbegehungTermDB term);

        public Task<int> Delete(int id);
    }
}
