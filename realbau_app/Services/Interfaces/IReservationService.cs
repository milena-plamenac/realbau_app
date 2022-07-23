using realbau_app.Models;

namespace realbau_app.Services.Interfaces
{
    public interface IReservationService
    {
        public Task<int> HausbegehungTerm(HausbegehungReservation hausbegehungReservation);

        //public Task<int> MontazeTerm();
    }
}
