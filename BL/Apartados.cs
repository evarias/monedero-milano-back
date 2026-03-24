using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Apartados
    {
        private readonly DL.IStoredProcedureService _dbService;

        public Apartados(DL.IStoredProcedureService dbService)
        {
            _dbService = dbService;
        }

        public ML.Result GetByIdCliente(string Telefono, string codigoSMS, string plastico)
        {
            ML.Result result = new ML.Result();

            try
            {
                var query = _dbService.ExecuteStoredProcedure<DL.ApartadoGetByIdDTO>(
                    "BOPOS",
                    "Apartados.sp_obten_apartado_cliente",
                    new { Telefono, codigoSMS, plastico }
                ).ToList();

                if (query.Count > 0)
                {
                    result.Objects = query.Cast<object>().ToList();
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontraron apartados para el cliente.";
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrió un error al obtener los apartados: " + ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}