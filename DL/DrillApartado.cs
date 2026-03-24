using System;
using System.Collections.Generic;

namespace DL;

public partial class DrillApartado
{
    public DateOnly? Fecha { get; set; }

    public int? CodigoTienda { get; set; }

    public string? Estatus { get; set; }

    public string? EstatusApartado { get; set; }

    public string? CodigoCliente { get; set; }

    public string? CodigoClienteLealtad { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Telefono { get; set; }

    public string? FolioApartado { get; set; }

    public string? Foliocreo { get; set; }

    public string? FolioTrxLiquido { get; set; }

    public string? FolioTrxCancelo { get; set; }

    public string? FolioTrxCedio { get; set; }

    public decimal? MontoApartado { get; set; }

    public decimal? ImportePagado { get; set; }

    public decimal? Saldo { get; set; }

    public string? Sku { get; set; }

    public string? Estilo { get; set; }

    public string? Descripcion { get; set; }

    public string? NumeroProveedor { get; set; }

    public string? Proveedor { get; set; }

    public string? NumeroDepartamento { get; set; }

    public string? Departamento { get; set; }

    public string? NumeroSubDepartamento { get; set; }

    public string? SubDepartamento { get; set; }

    public string? CodigoClase { get; set; }

    public string? Clase { get; set; }

    public string? NumeroSubClase { get; set; }

    public string? SubClase { get; set; }

    public int? Pagos { get; set; }

    public decimal? ImportePagadoAbono { get; set; }

    public int? Vence { get; set; }

    public DateOnly? FechaApartado { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public int? DiasRestantes { get; set; }

    public string? CodigoSms { get; set; }

    public string? Plastico { get; set; }
}
