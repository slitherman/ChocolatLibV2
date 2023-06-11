using CharlottesStockAPIV2.Repos;
using ChocolatLibV2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharlottesStockAPIV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EasterEggsController : ControllerBase
    {
        public IEasterEggsRepository _repo { get; set; }

        public EasterEggsController(IEasterEggsRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<EasterEgg> GetAllEasterEggs()
        {
            var easterEggs = _repo.GetAllEasterEggs();
            if (easterEggs.Count == 0)
            {
                return NoContent();
            }
            return Ok(easterEggs);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EasterEgg> GetEasterEggByProductNo(int id)
        {
            var easterEgg = _repo.GetEasterEggByProductNo(id);
            if (easterEgg == null)
            {
                return NotFound();
            }
            return Ok(easterEgg);
        }
        [HttpGet("lowstock/{stock}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<EasterEgg> GetLowStock(int stock)
        {
            var easterEggs = _repo.GetLowStock(stock);
            if (easterEggs.Count == 0)
            {
                return NoContent();
            }
            return Ok(easterEggs);
        }
        [HttpPut("{productno}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EasterEgg> Update([FromBody] EasterEgg easterEgg, int productno)
        {
           var easterEggToUpdate = _repo.GetEasterEggByProductNo(productno);
            try {                 if (easterEggToUpdate != null)
                {
                   var updatedEasterEgg = _repo.Update(easterEgg);
                    return Ok(updatedEasterEgg);
                }
                return Ok(easterEggToUpdate);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }


    }
}
