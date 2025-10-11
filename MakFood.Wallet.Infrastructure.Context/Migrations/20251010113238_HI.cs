using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakFood.Wallet.Infrastructure.Context.Migrations
{
    /// <inheritdoc />
    public partial class HI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isPaied",
                table: "Wallets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_WalletId",
                table: "OrderDetails",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_WalletId",
                table: "Accounts",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Wallets_WalletId",
                table: "Accounts",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "WalletId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Accounts_Wallets_WalletId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Wallets_WalletId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_WalletId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_WalletId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "isPaied",
                table: "Wallets");
        }
    }
}
