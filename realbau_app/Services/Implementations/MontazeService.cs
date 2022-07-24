using AutoMapper;
using realbau_app.api.Models;
using realbau_app.api.Repositories.Interfaces;
using realbau_app.Models;
using realbau_app.Services.Interfaces;

namespace realbau_app.Services.Implementations
{
    public class MontazeService: IMontazeService
    {
        private IMontazeTermRepository montazeTermRepository;
        private IMapper mapper;

        public MontazeService(IMontazeTermRepository montazeTermRepository, IMapper mapper)
        {
            this.montazeTermRepository = montazeTermRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MontazeTerm>> MontazeTermsForDate(string city, string pop, int year, int month, int date)
        {
            List<MontazeTermDB> terms = await this.montazeTermRepository.MontazeTermsForDate(city, pop, year, month, date) as List<MontazeTermDB>;

            List<Models.MontazeTerm> result =
                                    this.mapper.Map<List<MontazeTermDB>, List<Models.MontazeTerm>>(terms);
            return result;
        }
    }
}
