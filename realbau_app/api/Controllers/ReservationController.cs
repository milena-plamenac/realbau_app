using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using realbau_app.api.Models;
using realbau_app.api.Repositories.Interfaces;

namespace realbau_app.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IAddressRepository addressRepository;
        private IHausbegehungRepository hausbegehungRepository;
        private IHausbegehungTermRepository hausbegehungTermRepository;

        public ReservationController(IAddressRepository addressRepository, IHausbegehungRepository hausbegehungRepository, IHausbegehungTermRepository hausbegehungTermRepository)
        {
            this.addressRepository = addressRepository;
            this.hausbegehungRepository = hausbegehungRepository;
            this.hausbegehungTermRepository = hausbegehungTermRepository;
        }

        [HttpPost("HausbegehungTerm")]
        public async Task<int> HausbegehungTerm([FromBody] HausbegehungReservation hausbegehungReservation)
        {
            // TODO: Add city, pop validation
            try
            {
                var address = await this.addressRepository.GetAddressById(hausbegehungReservation.address_id);

                var hausbegehungTerm = await this.hausbegehungTermRepository.GetById(hausbegehungReservation.hbterm_id);

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

        //public async Task<int> MontazeTerm() { }
    }
}
