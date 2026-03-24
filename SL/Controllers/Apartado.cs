using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Apartado : ControllerBase
    {
        private readonly BL.Apartados _apartadosBL;
        public Apartado(BL.Apartados apartadosBL)
        {
            _apartadosBL = apartadosBL;
        }

        [HttpGet]
        [Route("GetByIdCliente")]
        public IActionResult GetByIdCliente(string CodigoCliente) { 
            ML.Result result = _apartadosBL.GetByIdCliente(CodigoCliente);  
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
            }
        }
    }
}
