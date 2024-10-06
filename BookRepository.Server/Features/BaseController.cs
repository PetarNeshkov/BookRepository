using Microsoft.AspNetCore.Mvc;

namespace BookRepository.Api.Features
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class BaseApiController : ControllerBase
    {
    }
}
