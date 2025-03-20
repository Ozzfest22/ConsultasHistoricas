namespace ConsultasHistoricas.Domain.Models.Oracle
{
    public partial class ResultadosPacienteOracle
    {
        public string? OrdenAño { get; set; }

        public string? NroOrden { get; set; }

        public string? CabeceraOrdServicio { get; set; }

        public string? Paciente { get; set; }

        public int? Edad { get; set; }

        public string? Medico { get; set; }

        public DateTime? FechaOrden { get; set; }

        public string? CodigoHistoria { get; set; }

        public string? Resultado { get; set; }

        public string? Examen { get; set; }

        public string? Metodo { get; set; }

        public string? Unidad { get; set; }

        public string? ValorReferencial { get; set; }

        public string? Seccion { get; set; }

        public string? Perfil { get; set; }

        public DateTime? FechaMuestra { get; set; }

        public string? ResultadoOrigen { get; set; }

        public string? ResultadoNuevo { get; set; }

        public string? Servicio { get; set; }
    }

    public partial class ResultadosPacienteOracle
    {
        public int Row_Num { get; set; }

        public int FilteredCount { get; set; }

        public string TotalCount { get; set; }
    }
}
