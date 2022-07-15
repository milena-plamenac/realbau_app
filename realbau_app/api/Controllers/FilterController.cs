using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using realbau_app.api.Models;
using realbau_app.api.Repositories.Interfaces;

namespace realbau_app.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private IAddressRepository addressRepository;

        public FilterController(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        [HttpPost]
        public async Task<IEnumerable<AddressDetails>> Addresses(FilterModel filterModel)
        {
            return await this.addressRepository.Filter(filterModel);
        }
    }
}
