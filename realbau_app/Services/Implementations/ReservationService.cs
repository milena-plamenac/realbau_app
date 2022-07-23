using realbau_app.api.Repositories.Interfaces;
using realbau_app.Models;
using realbau_app.Services.Interfaces;

namespace realbau_app.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private IAddressRepository addressRepository;
        private IHausbegehungRepository hausbegehungRepository;
        private IHausbegehungTermRepository hausbegehungTermRepository;

        public ReservationService(IAddressRepository addressRepository, IHausbegehungRepository hausbegehungRepository, IHausbegehungTermRepository hausbegehungTermRepository)
        {
            this.addressRepository = addressRepository;
            this.hausbegehungRepository = hausbegehungRepository;
            this.hausbegehungTermRepository = hausbegehungTermRepository;
        }

        public async Task<int> HausbegehungTerm(HausbegehungReservation hausbegehungReservation)
        {
            try
            {
                var address = await this.addressRepository.GetAddressById(hausbegehungReservation.address_id);

                var hausbegehungTerm = await this.hausbegehungTermRepository.GetById(hausbegehungReservation.hbterm_id);

                if (hausbegehungTerm.busy == 1)
                    return -1;

                var hausbegehung = await this.hausbegehungRepository.Get(address.id);

                hausbegehung.hbdate = hausbegehungTerm.hbdate;
                hausbegehung.hbfrom = hausbegehungTerm.hbfrom;
                hausbegehung.hbto = hausbegehungTerm.hbto;

                var hbUpdate = await this.hausbegehungRepository.Update(address.id, hausbegehung);

                hausbegehungTerm.busy = 1;

                var hbTermUpdate = await this.hausbegehungTermRepository.Update(hausbegehungTerm.id, hausbegehungTerm);

                return 1;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}
