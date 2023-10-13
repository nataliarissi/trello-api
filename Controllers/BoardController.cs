
using Microsoft.AspNetCore.Mvc;

namespace TrelloAPI.Controllers
{
    [ApiController]
    [Route("boards")]
    [Produces("application/json")]
    public class BoardController : ControllerBase
    {
        [HttpGet]
        public string ObterCard(){
            return "Luke é lindo";
        }

        [HttpGet]
        [Route("numero-card")]
        public double ObterNumeroCard(){
            return 33;
        }
    }
}