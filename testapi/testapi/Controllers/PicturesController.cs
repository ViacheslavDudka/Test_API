using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace testapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PicturesController : ControllerBase
    {
        private readonly ILogger<PicturesController> _logger;

        public PicturesController(ILogger<PicturesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Paint>> GetAsync()
        {
            await PaintsStorage.Init();

            return PaintsStorage.Paints;
        }

        [HttpGet("getimages")]
        public async Task<IEnumerable<Paint>> GetImagesAsync(string author)
        {
            await PaintsStorage.Init();

            return PaintsStorage.Paints.Where(x => x.Author == author);
        }
    }
}
