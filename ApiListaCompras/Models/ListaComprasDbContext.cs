using Microsoft.EntityFrameworkCore;


namespace ApiListaCompras.Models
{
    // REPRESENTACION DE LA BASE DE DATOS PARA ENTITY FRAMEWORK
    public class ListaComprasDbContext: DbContext
    {
        public ListaComprasDbContext(DbContextOptions<ListaComprasDbContext> options) : base(options) { }

        //REPRESENTACION DE LA TABLA EN DB
        public DbSet<Item> Items { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar el valor predeterminado para CreatedDate
            modelBuilder.Entity<Item>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            base.OnModelCreating(modelBuilder);
        }
    }
}
