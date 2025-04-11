using DB.Models;

namespace PosFarmacia.helpers
{
    public class ResponsePaginado <T>
    {
        public int TotalRegistros { get; set; }
        public int NumeroPagina { get; set; }
        public int TamanioPagina { get; set; }
        public List<T> Dato { get; set; }
    }
}
