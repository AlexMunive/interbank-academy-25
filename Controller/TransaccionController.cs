using MediatR;
using Microsoft.AspNetCore.Mvc;
using Interbank.Api;  

namespace Interbank.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransaccionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransaccionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Ruta GET que ejecuta el handler para obtener el resumen de las transacciones
        [HttpGet]
        public async Task<ActionResult<TransaccionDTO>> GetResumen()
        {
            var query = new GetTransaccionResumenQuery();
            var resumen = await _mediator.Send(query);

            if (resumen == null)
            {
                return NotFound();
            }

            return Ok(resumen);
        }
    }
}
