using realbau_app.api.Models;

namespace realbau_app.api.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        public Task<IEnumerable<AddressDetails>> GetAddresses();

        public Task<AddressDetails> GetAddressById(int id);

        public Task<AddressDetails> GetAddressByInfo(string? city, string? tzip, string? street, int? housenumber, string? subnumber, int? unit);

        public Task<AddressDB> Insert(AddressDB address);

        public Task<int> CheckAddressRnc(string city, string tzip, string street, int housenumber, string subnumber, int unit, int newrnc);
    }
}
