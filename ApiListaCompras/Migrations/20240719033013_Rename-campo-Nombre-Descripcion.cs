using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiListaCompras.Migrations
{
    /// <inheritdoc />
    public partial class RenamecampoNombreDescripcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
            name: "Nombre",
            table: "Items",
            newName: "Descripcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
            name: "Descripcion",
            table: "Items",
            newName: "Nombre");
        }
    }
}
