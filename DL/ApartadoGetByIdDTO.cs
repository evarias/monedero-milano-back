using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class ApartadoGetByIdDTO
    {
        public string? CodigoCliente { get; set; }
        public string? Estatus { get; set; }
        public string? EstatusApartado { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int DiasRestantes { get; set; }
        public string? Descripcion { get; set; }
        public decimal MontoApartado { get; set; }
        public decimal ImportePagado { get; set; }
        public decimal Saldo { get; set; }
        public int Piezas { get; set; }
        public decimal TotalApartados { get; set; }
        public decimal TotalPagado { get; set; }
        public decimal TotalSaldo { get; set; }
        public decimal Reembolso { get; set; }
    }
}
