using AutoMapper;
using realbau_app.api.Models;
using realbau_app.api.Repositories.Interfaces;
using realbau_app.Models;
using realbau_app.Services.Interfaces;

namespace realbau_app.Services.Implementations
{
    public class HausbegehungService : IHausbegehungService
    {
        private IHausbegehungRepository hausbegehungRepository;
        private IMapper mapper;

        public HausbegehungService(IHausbegehungRepository hausbegehungRepository, IMapper mapper)
        {
            this.hausbegehungRepository = hausbegehungRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<HausbegehungTerm>> HausbegehungTermsForDate(string city, string pop, int year, int month, int date)
        {
            List<HausbegehungTermDB> terms = await this.hausbegehungRepository.HausbegehungTermsForDate(city, pop, year, month, date) as List<HausbegehungTermDB>;

            List<Models.HausbegehungTerm> result =
                                    this.mapper.Map<List<HausbegehungTermDB>, List<Models.HausbegehungTerm>>(terms);
            return result;
        }
    }
}
