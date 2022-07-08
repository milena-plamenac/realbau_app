using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using realbau_app.api.Models;
using realbau_app.api.Repositories.Interfaces;

namespace realbau_app.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private IImageRepository imageRepository;

        ImageController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        public bool Save([FromBody] ImageDB image)
        {
            var saveResult = this.imageRepository.Save(image.image_type, image.address_id, image.name);

            return saveResult.Result;
        }
    }
}
