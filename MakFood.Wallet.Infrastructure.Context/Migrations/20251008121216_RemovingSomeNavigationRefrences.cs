using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakFood.Wallet.Infrastructure.Context.Migrations
{
    /// <inheritdoc />
    public partial class RemovingSomeNavigationRefrences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_WalletId",
                table: "Transactions",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Wallets_WalletId",
                table: "Transactions",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "WalletId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Wallets_WalletId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_WalletId",
                table: "Transactions");

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
    }
}
