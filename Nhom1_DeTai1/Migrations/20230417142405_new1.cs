using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom1_DeTai1.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_InvoiceId",
                table: "InvoiceDetail",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_ProductId",
                table: "InvoiceDetail",
                column: "ProductId");

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

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetail_InvoiceId",
                table: "InvoiceDetail");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetail_ProductId",
                table: "InvoiceDetail");
        }
    }
}
