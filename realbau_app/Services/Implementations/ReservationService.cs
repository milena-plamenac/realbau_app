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
        private IMontazeRepository montazeRepository;
        private IMontazeTermRepository montazeTermRepository;

        public ReservationService(IAddressRepository addressRepository, IHausbegehungRepository hausbegehungRepository, IHausbegehungTermRepository hausbegehungTermRepository,
            IMontazeRepository montazeRepository, IMontazeTermRepository montazeTermRepository)
        {
            this.addressRepository = addressRepository;
            this.hausbegehungRepository = hausbegehungRepository;
            this.hausbegehungTermRepository = hausbegehungTermRepository;
            this.montazeRepository = montazeRepository;
            this.montazeTermRepository = montazeTermRepository;
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

        public async Task<int> MontazeTerm(MontazeReservation montazeReservation)
        {
            try
            {
                var address = await this.addressRepository.GetAddressById(montazeReservation.address_id);

                var montazeTerm = await this.montazeTermRepository.GetById(montazeReservation.mterm_id);

                if (montazeTerm.busy == 1)
                    return -1;

                var montaze = await this.montazeRepository.Get(address.id);

                montaze.mdate = montazeTerm.mdate;
                montaze.mfrom = montazeTerm.mfrom;
                montaze.mto = montazeTerm.mto;

                var mUpdate = await this.montazeRepository.Update(address.id, montaze);

                montazeTerm.busy = 1;

                var mTermUpdate = await this.montazeTermRepository.Update(montazeTerm.id, montazeTerm);

                return 1;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}
