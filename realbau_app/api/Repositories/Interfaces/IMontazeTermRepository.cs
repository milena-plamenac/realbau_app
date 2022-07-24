using realbau_app.api.Models;

namespace realbau_app.api.Repositories.Interfaces
{
    public interface IMontazeTermRepository
    {
        public Task<IEnumerable<MontazeTermDB>> MontazeTermsForDate(string city, string pop, int year, int month, int date);

        public Task<MontazeTermDB> GetById(int id);

        public Task<MontazeTermDB> Insert(MontazeTermDB term);

        public Task<int> Update(int id, MontazeTermDB term);

        public Task<int> Delete(int id);
    }
}
