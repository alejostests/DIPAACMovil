using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DIPAAC.Controllers
{
    /// <summary>
    ///     Expose methods to interact with applicants data
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RespuestasController : ControllerBase
    {
        private readonly IRespuestaRepository
    }
}