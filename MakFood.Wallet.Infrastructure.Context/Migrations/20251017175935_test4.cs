using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakFood.Wallet.Infrastructure.Context.Migrations
{
    /// <inheritdoc />
    public partial class test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Wallets_WalletId",
                table: "OrderDetails");

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Wallets_WalletId",
                table: "OrderDetails",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "WalletId");
        }
    }
}
