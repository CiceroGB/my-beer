using Microsoft.AspNetCore.Mvc;
using MyBeer.Domain.Entities;
using MyBeer.Application.Interfaces;


namespace MyBeer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _beerService;

        public BeerController(IBeerService beerService)
        {
            _beerService = beerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beer>>> GetAllBeers(CancellationToken cancellationToken)
        {
            var beers = await _beerService.GetAllBeersAsync(cancellationToken);
            return Ok(beers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Beer>> GetBeer(Guid id, CancellationToken cancellationToken)
        {
            var beer = await _beerService.GetBeerByIdAsync(id, cancellationToken);
            if (beer == null)
                return NotFound();

            return Ok(beer);
        }

        [HttpPost]
        public async Task<ActionResult<Beer>> CreateBeer([FromBody] Beer beer, CancellationToken cancellationToken)
        {
            await _beerService.AddBeerAsync(beer, cancellationToken);
            return CreatedAtAction(nameof(GetBeer), new { id = beer.Id }, beer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBeer(Guid id, [FromBody] Beer beer, CancellationToken cancellationToken)
        {
            if (id != beer.Id)
                return BadRequest("ID mismatch");

            var existingBeer = await _beerService.GetBeerByIdAsync(id, cancellationToken);
            if (existingBeer == null)
                return NotFound();

            await _beerService.UpdateBeerAsync(beer, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeer(Guid id, CancellationToken cancellationToken)
        {
            var beer = await _beerService.GetBeerByIdAsync(id, cancellationToken);
            if (beer == null)
                return NotFound();

            await _beerService.DeleteBeerAsync(beer, cancellationToken);
            return NoContent();
        }
    }
}
