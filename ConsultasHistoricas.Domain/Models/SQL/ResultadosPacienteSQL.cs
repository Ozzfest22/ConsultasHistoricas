﻿namespace ConsultasHistoricas.Domain.Models.SQL
{
    public partial class ResultadosPacienteSQL
    {
        public string CodigoHistoria { get; set; }

        public string Nombre { get; set; }

        public string OrdenAño { get; set; }

        public string OrdenNumero { get; set; }

        public DateTime OrdenFecha { get; set; }

        public string NombreExamen { get; set; }

        public DateTime FechaIngreso { get; set; }

        public string Resultado { get; set; }

        public DateTime FechaResultado { get; set; }

        public string UltimoResultado { get; set; }

        public DateTime FechaUltResultado { get; set; }

        public string UltimoResultado2 { get; set; }

        public DateTime FechaUltResultado2 { get; set; }
    }

    public partial class ResultadosPacienteSQL
    {
        public int TotalCount { get; set; }

        public int FilteredCount { get; set; }
    }
}
