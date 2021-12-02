using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinalLaboIV.Data.Migrations
{
    public partial class provprod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProveedoresProductos_Products_productoId",
                table: "ProveedoresProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProveedoresProductos_Proveedores_proveedorId",
                table: "ProveedoresProductos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProveedoresProductos",
                table: "ProveedoresProductos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProveedoresProductos");

            migrationBuilder.RenameColumn(
                name: "proveedorId",
                table: "ProveedoresProductos",
                newName: "ProveedorId");

            migrationBuilder.RenameColumn(
                name: "productoId",
                table: "ProveedoresProductos",
                newName: "ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_ProveedoresProductos_proveedorId",
                table: "ProveedoresProductos",
                newName: "IX_ProveedoresProductos_ProveedorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProveedoresProductos_productoId",
                table: "ProveedoresProductos",
                newName: "IX_ProveedoresProductos_ProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProveedoresProductos",
                table: "ProveedoresProductos",
                columns: new[] { "IdProveedor", "IdProducto" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProveedoresProductos_Products_ProductoId",
                table: "ProveedoresProductos",
                column: "ProductoId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProveedoresProductos_Proveedores_ProveedorId",
                table: "ProveedoresProductos",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProveedoresProductos_Products_ProductoId",
                table: "ProveedoresProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProveedoresProductos_Proveedores_ProveedorId",
                table: "ProveedoresProductos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProveedoresProductos",
                table: "ProveedoresProductos");

            migrationBuilder.RenameColumn(
                name: "ProveedorId",
                table: "ProveedoresProductos",
                newName: "proveedorId");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "ProveedoresProductos",
                newName: "productoId");

            migrationBuilder.RenameIndex(
                name: "IX_ProveedoresProductos_ProveedorId",
                table: "ProveedoresProductos",
                newName: "IX_ProveedoresProductos_proveedorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProveedoresProductos_ProductoId",
                table: "ProveedoresProductos",
                newName: "IX_ProveedoresProductos_productoId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProveedoresProductos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProveedoresProductos",
                table: "ProveedoresProductos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProveedoresProductos_Products_productoId",
                table: "ProveedoresProductos",
                column: "productoId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProveedoresProductos_Proveedores_proveedorId",
                table: "ProveedoresProductos",
                column: "proveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
