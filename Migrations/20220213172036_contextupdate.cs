using Microsoft.EntityFrameworkCore.Migrations;

namespace Smart_Cookers.Migrations
{
    public partial class contextupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutletProduct_Outlets_OutletId",
                table: "OutletProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OutletProduct_Products_ProductId",
                table: "OutletProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutletProduct",
                table: "OutletProduct");

            migrationBuilder.RenameTable(
                name: "OutletProduct",
                newName: "OutletProducts");

            migrationBuilder.RenameIndex(
                name: "IX_OutletProduct_ProductId",
                table: "OutletProducts",
                newName: "IX_OutletProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutletProducts",
                table: "OutletProducts",
                columns: new[] { "OutletId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OutletProducts_Outlets_OutletId",
                table: "OutletProducts",
                column: "OutletId",
                principalTable: "Outlets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutletProducts_Products_ProductId",
                table: "OutletProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutletProducts_Outlets_OutletId",
                table: "OutletProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OutletProducts_Products_ProductId",
                table: "OutletProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutletProducts",
                table: "OutletProducts");

            migrationBuilder.RenameTable(
                name: "OutletProducts",
                newName: "OutletProduct");

            migrationBuilder.RenameIndex(
                name: "IX_OutletProducts_ProductId",
                table: "OutletProduct",
                newName: "IX_OutletProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutletProduct",
                table: "OutletProduct",
                columns: new[] { "OutletId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OutletProduct_Outlets_OutletId",
                table: "OutletProduct",
                column: "OutletId",
                principalTable: "Outlets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutletProduct_Products_ProductId",
                table: "OutletProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
