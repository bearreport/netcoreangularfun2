using Microsoft.AspNetCore.Mvc;


namespace backend.Controllers
{
    [ApiController]
    [Route("pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;


        public PokemonController(ILogger<PokemonController> logger)
    {
        _logger = logger;
    }

    
        [HttpGet]
        public IEnumerable<Pokemon> Get()
        {
            return Pokemon.getPokemonList();
        }

    }
}
