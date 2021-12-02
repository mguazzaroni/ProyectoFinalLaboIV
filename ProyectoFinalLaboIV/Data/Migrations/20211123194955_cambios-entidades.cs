using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinalLaboIV.Data.Migrations
{
    public partial class cambiosentidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Marcas");

            migrationBuilder.AddColumn<int>(
                name: "productoId",
                table: "ProveedoresProductos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "proveedorId",
                table: "ProveedoresProductos",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Provincia",
                table: "Proveedores",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Proveedores",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Localidad",
                table: "Proveedores",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Proveedores",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MarcaProductoId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProveedorProductoId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Marcas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProveedoresProductos_productoId",
                table: "ProveedoresProductos",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedoresProductos_proveedorId",
                table: "ProveedoresProductos",
                column: "proveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MarcaProductoId",
                table: "Products",
                column: "MarcaProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProveedorProductoId",
                table: "Products",
                column: "ProveedorProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Marcas_MarcaProductoId",
                table: "Products",
                column: "MarcaProductoId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Proveedores_ProveedorProductoId",
                table: "Products",
                column: "ProveedorProductoId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Marcas_MarcaProductoId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Proveedores_ProveedorProductoId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProveedoresProductos_Products_productoId",
                table: "ProveedoresProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProveedoresProductos_Proveedores_proveedorId",
                table: "ProveedoresProductos");

            migrationBuilder.DropIndex(
                name: "IX_ProveedoresProductos_productoId",
                table: "ProveedoresProductos");

            migrationBuilder.DropIndex(
                name: "IX_ProveedoresProductos_proveedorId",
                table: "ProveedoresProductos");

            migrationBuilder.DropIndex(
                name: "IX_Products_MarcaProductoId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProveedorProductoId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "productoId",
                table: "ProveedoresProductos");

            migrationBuilder.DropColumn(
                name: "proveedorId",
                table: "ProveedoresProductos");

            migrationBuilder.DropColumn(
                name: "MarcaProductoId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProveedorProductoId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Marcas");

            migrationBuilder.AlterColumn<string>(
                name: "Provincia",
                table: "Proveedores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Proveedores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Localidad",
                table: "Proveedores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Proveedores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Marcas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
