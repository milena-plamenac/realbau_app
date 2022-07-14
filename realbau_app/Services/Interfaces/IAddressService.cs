using realbau_app.Models;

namespace realbau_app.Services.Interfaces
{
    public interface IAddressService
    {
        public Task<IEnumerable<AddressDetails>> GetAddresses();
    }
}
