namespace ApiListaCompras.Models
{
    public class Item
    {
        public int Id { get; set; }
        public required string Descripcion { get; set; }
        public required double Precio { get; set; }
        public int? Sitio { get; set; }
        public DateOnly CreatedDate { get; set; }
    }
}
