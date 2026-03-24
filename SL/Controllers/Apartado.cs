using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using POS_Secrets;
using System.Globalization;
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
        public IActionResult GetByIdCliente(string Telefono, string codigoSMS, string plastico, string fechaa) { 
            
           string fecha =  POS_Secrets.POSSecret.DecodeBase36(fechaa);
            string fecham = DataFormatString(fecha);

            if (DateTime.TryParse(fecham, out DateTime fechaDesencriptada))
            {

                if (fechaDesencriptada.Date == DateTime.Today)
                {
                    string telefono = POS_Secrets.POSSecret.Decrypt(Telefono);
                    string codigo = POS_Secrets.POSSecret.Decrypt(codigoSMS);
                    string plas = POS_Secrets.POSSecret.Decrypt(plastico);

                    ML.Result result = _apartadosBL.GetByIdCliente(telefono, codigo, plas);
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
            else
            {
                Console.WriteLine("La fecha no es válida");
            }

           return BadRequest();
        }

        public static string DataFormatString(string fecha)
        {
            if (DateTime.TryParseExact(
                fecha,
                "yyyyMMddHHmmss",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime fechaConvertida))
            {
                return fechaConvertida.ToString("dd/MM/yyyy HH:mm:ss");
            }

            return "Fecha inválida";
        }
    }
}
