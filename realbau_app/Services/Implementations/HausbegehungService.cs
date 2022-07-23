using AutoMapper;
using realbau_app.api.Models;
using realbau_app.api.Repositories.Interfaces;
using realbau_app.Models;
using realbau_app.Services.Interfaces;

namespace realbau_app.Services.Implementations
{
    public class HausbegehungService : IHausbegehungService
    {
        private IHausbegehungTermRepository hausbegehungTermRepository;
        private IMapper mapper;

        public HausbegehungService(IHausbegehungTermRepository hausbegehungTermRepository, IMapper mapper)
        {
            this.hausbegehungTermRepository = hausbegehungTermRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<HausbegehungTerm>> HausbegehungTermsForDate(string city, string pop, int year, int month, int date)
        {
            List<HausbegehungTermDB> terms = await this.hausbegehungTermRepository.HausbegehungTermsForDate(city, pop, year, month, date) as List<HausbegehungTermDB>;

            List<Models.HausbegehungTerm> result =
                                    this.mapper.Map<List<HausbegehungTermDB>, List<Models.HausbegehungTerm>>(terms);
            return result;
        }
    }
}
