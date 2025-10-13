using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakFood.Wallet.Infrastructure.Context.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isPaied",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "TotalPaid",
                table: "OrderDetails",
                newName: "TotalAmount");

            migrationBuilder.AddColumn<bool>(
                name: "isPaied",
                table: "OrderDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_WalletId",
                table: "OrderDetails",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Wallets_WalletId",
                table: "OrderDetails",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "WalletId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Wallets_WalletId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_WalletId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "isPaied",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "OrderDetails",
                newName: "TotalPaid");

            migrationBuilder.AddColumn<bool>(
                name: "isPaied",
                table: "Wallets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
