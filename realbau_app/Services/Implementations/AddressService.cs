using AutoMapper;
using realbau_app.api.Models;
using realbau_app.api.Repositories.Interfaces;
using realbau_app.Services.Interfaces;

namespace realbau_app.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private IAddressRepository addressRepository;
        private IMapper mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            this.addressRepository = addressRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<realbau_app.Models.AddressDetails>> GetAddresses()
        {
            List<AddressDetails> addressDetails = await this.addressRepository.GetAddresses() as List<AddressDetails>;

            List<Models.AddressDetails> result =
                                    this.mapper.Map<List<AddressDetails>, List<Models.AddressDetails>>(addressDetails);
            return result;
        }

        public async Task<realbau_app.Models.AddressDetails> GetAddressByInfo(Models.AddressInfo addressInfo)
        {
            AddressDetails addressDetails = await this.addressRepository
                .GetAddressByInfo(addressInfo.city, addressInfo.tzip, addressInfo.street, addressInfo.housenumber, addressInfo.subnumber, addressInfo.unit);

            Models.AddressDetails result =
                                    this.mapper.Map<AddressDetails, Models.AddressDetails>(addressDetails);
            return result;
        }

        public async Task<realbau_app.Models.AddressDetails> GetAddressById(int id)
        {
            AddressDetails addressDetails = await this.addressRepository
                .GetAddressById(id);

            Models.AddressDetails result =
                                    this.mapper.Map<AddressDetails, Models.AddressDetails>(addressDetails);
            return result;
        }

        public async Task<IEnumerable<Models.AddressDetails>> Filter(Models.FilterModel filterModel)
        {
            List<AddressDetails> addressDetails = await this.addressRepository.Filter(this.mapper.Map<FilterModel>(filterModel)) as List<AddressDetails>;

            List<Models.AddressDetails> result =
                                    this.mapper.Map<List<AddressDetails>, List<Models.AddressDetails>>(addressDetails);
            return result;
        }

    }
}
