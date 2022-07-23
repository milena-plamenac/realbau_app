using realbau_app.api.Models;

namespace realbau_app.api.Repositories.Interfaces
{
    public interface IHausbegehungRepository
    {
        public Task<HausbegehungDB> Get(int address_id);

        public Task<int> Insert(int address_id, HausbegehungDB hausbegehung);

        public Task<int> Update(int address_id, HausbegehungDB hausbegehung);

        public Task<int> Delete(int address_id);
    }
}
