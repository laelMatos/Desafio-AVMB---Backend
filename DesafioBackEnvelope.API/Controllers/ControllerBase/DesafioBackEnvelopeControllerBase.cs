using DesafioBackEnvelope.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackEnvelope.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultResponse))]
    public class DesafioBackEnvelopeControllerBase : ControllerBase
    {
    }
}
