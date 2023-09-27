using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
  [Route("/api/[controller]")]
  [ApiController]
  public class SuperHeroController : ControllerBase
  {
    private static List<SuperHero> superHeroes = new List<SuperHero>
      {
        new SuperHero {
          Id = 1,
          Name = "Spider-Man",
          FirstName = "Peter",
          LastName = "Parker",
          Place = "New York"
        },
        new SuperHero {
          Id = 2,
          Name = "Batman",
          FirstName = "Bruce",
          LastName = "Wayne",
          Place = "Gotham"
        }
      };

    [HttpGet]
    [ProducesResponseType(typeof(SuperHero), 200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [ProducesResponseType(503)]
    public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
    {
      return Ok(superHeroes);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(SuperHero), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
    {
      var superHero = superHeroes.Find(x => x.Id == id);
      if (superHero == null)
      {
        return NotFound("Super Hero not found");
      }

      return Ok(superHero);
    }

    [HttpPost]
    [ProducesResponseType(typeof(SuperHero), 201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(503)]
    public async Task<ActionResult<SuperHero>> AddHero([FromBody] SuperHero superHero)
    {
      superHeroes.Add(superHero);
      return Ok();
    }
  }
}