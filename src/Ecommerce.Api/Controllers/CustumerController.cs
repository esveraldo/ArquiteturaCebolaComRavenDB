namespace Ecommerce.Api.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class CustumerController : ControllerBase
    {
        private readonly ICustumerAppService _custumerAppService;

        public CustumerController(ICustumerAppService custumerAppService)
        {
            _custumerAppService = custumerAppService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] CustumerDto custumerDto)
        {
            try
            {
                _custumerAppService.SaveCustumer(custumerDto);
                
            }
            catch (DuplicateWaitObjectException e)
            {

                return Conflict(e);
            }
            return Created("", custumerDto);
        }
    }
}
