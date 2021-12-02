using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinalLaboIV.Data.Migrations
{
    public partial class cambiosentidades2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Marcas_MarcaProductoId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Proveedores_ProveedorProductoId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MarcaProductoId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProveedorProductoId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MarcaProductoId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProveedorProductoId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProveedorId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MarcaId",
                table: "Products",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProveedorId",
                table: "Products",
                column: "ProveedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Marcas_MarcaId",
                table: "Products",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Proveedores_ProveedorId",
                table: "Products",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Marcas_MarcaId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Proveedores_ProveedorId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MarcaId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProveedorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProveedorId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "MarcaProductoId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProveedorProductoId",
                table: "Products",
                type: "int",
                nullable: true);

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
        }
    }
}
