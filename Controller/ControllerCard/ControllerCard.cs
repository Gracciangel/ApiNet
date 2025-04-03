using DAL.Interfaces.Cards;
using MDL.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsers.Controller.ControllerCard
{
    [ApiController]
    [Route("/card")]
    public class ControllerCard : ControllerBase
    {
        ICard _card;
        public ControllerCard(ICard card)
        {
            _card = card;
        }

        [HttpPost]
        public async Task<ActionResult> AddCardController([FromQuery] string email , [FromBody] AddCardDTO card)
        {
            try
            {
                var result = await _card.AddCard(email , card);
                if(result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.message);
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
    }
}
