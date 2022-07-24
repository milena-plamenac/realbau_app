using realbau_app.api.Models;

namespace realbau_app.api.Repositories.Interfaces
{
    public interface IMontazeRepository
    {
        public Task<MontazeDB> Get(int address_id);

        public Task<int> Insert(int address_id, MontazeDB montaze);

        public Task<int> Update(int address_id, MontazeDB montaze);

        public Task<int> Delete(int address_id);
    }
}
