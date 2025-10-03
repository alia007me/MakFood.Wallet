using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakFood.Wallet.Infrastructure.Context.Migrations
{
    /// <inheritdoc />
    public partial class ChangingPKInEventsourceconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WalletEvents",
                table: "WalletEvents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WalletEvents",
                table: "WalletEvents",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WalletEvents",
                table: "WalletEvents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WalletEvents",
                table: "WalletEvents",
                column: "WalletId");
        }
    }
}
