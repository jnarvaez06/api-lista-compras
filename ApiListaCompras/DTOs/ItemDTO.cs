namespace ApiListaCompras.DTOs
{
    public class ItemDTO
    {
        public int? Id { get; set; }
        public required string Descripcion { get; set; }
        public double Precio { get; set; }
        public int? Sitio { get; set; }

    }
}
