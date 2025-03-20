namespace ConsultasHistoricas.Domain.Models.Shared
{
    public class ListRequest
    {
        public string NombreBusqueda { get; set; } = "ABC";

        public int PageNo { get; set; } = 0;

        public int PageSize { get; set; } = 10;

        public string SortDirection { get; set; } = "ASC";
    }
}
