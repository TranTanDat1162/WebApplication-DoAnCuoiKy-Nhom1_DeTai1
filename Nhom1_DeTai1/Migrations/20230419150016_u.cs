using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom1_DeTai1.Migrations
{
    public partial class u : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetail_Invoice_InvoiceId",
                table: "InvoiceDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetail_Product_ProductId",
                table: "InvoiceDetail");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "InvoiceDetail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "InvoiceDetail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetail_Invoice_InvoiceId",
                table: "InvoiceDetail",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetail_Product_ProductId",
                table: "InvoiceDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetail_Invoice_InvoiceId",
                table: "InvoiceDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetail_Product_ProductId",
                table: "InvoiceDetail");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "InvoiceDetail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "InvoiceDetail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetail_Invoice_InvoiceId",
                table: "InvoiceDetail",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetail_Product_ProductId",
                table: "InvoiceDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
