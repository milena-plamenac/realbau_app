using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using realbau_app.api.Models;
using realbau_app.api.Repositories.Interfaces;

namespace realbau_app.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HausbegehungController : ControllerBase
    {
        private IHausbegehungRepository hausbegehungRepository;

        public HausbegehungController(IHausbegehungRepository hausbegehungRepository)
        {
            this.hausbegehungRepository = hausbegehungRepository;
        }

        [HttpGet("{address_id}")]
        public async Task<HausbegehungDB> Get(int address_id)
        {
            return await hausbegehungRepository.Get(address_id);
        }

        [HttpPost("{address_id}")]
        public async Task<int> Post(int address_id, [FromBody] HausbegehungDB hausbegehung)
        {
            return await hausbegehungRepository.Insert(address_id, hausbegehung);
        }

        [HttpPut("{address_id}")]
        public async Task<int> Put(int address_id, [FromBody] HausbegehungDB hausbegehung)
        {
            return await hausbegehungRepository.Update(address_id, hausbegehung);
        }

        [HttpDelete("{address_id}")]
        public async Task<int> Delete(int address_id)
        {
            return await hausbegehungRepository.Delete(address_id);
        }
    }
}
