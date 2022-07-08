

namespace realbau_app.api.Repositories.Interfaces
{
    public interface IImageRepository
    {
        public Task<bool> Save(string type, int address_id, string name);
    }
}
