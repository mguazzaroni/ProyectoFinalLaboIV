using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinalLaboIV.Data.Migrations
{
    public partial class cambiosentidades5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_ProveedoresProductos_ProveedorId",
                table: "ProveedoresProductos");

            migrationBuilder.DropColumn(
                name: "IdProveedor",
                table: "ProveedoresProductos");

            migrationBuilder.DropColumn(
                name: "IdProducto",
                table: "ProveedoresProductos");

            migrationBuilder.AlterColumn<int>(
                name: "ProveedorId",
                table: "ProveedoresProductos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "ProveedoresProductos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProveedoresProductos",
                table: "ProveedoresProductos",
                columns: new[] { "ProveedorId", "ProductoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProveedoresProductos_Products_ProductoId",
                table: "ProveedoresProductos",
                column: "ProductoId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProveedoresProductos_Proveedores_ProveedorId",
                table: "ProveedoresProductos",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "ProveedoresProductos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProveedorId",
                table: "ProveedoresProductos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IdProveedor",
                table: "ProveedoresProductos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProducto",
                table: "ProveedoresProductos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProveedoresProductos",
                table: "ProveedoresProductos",
                columns: new[] { "IdProveedor", "IdProducto" });

            migrationBuilder.CreateIndex(
                name: "IX_ProveedoresProductos_ProveedorId",
                table: "ProveedoresProductos",
                column: "ProveedorId");

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
    }
}
