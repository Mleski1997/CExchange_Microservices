using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CExchange.Services.Wallets.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Address = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WalletName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Address);
                });

            migrationBuilder.CreateTable(
                name: "CryptoCurrencies",
                columns: table => new
                {
                    CryptoCurrencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WalletAddress = table.Column<string>(type: "nvarchar(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoCurrencies", x => x.CryptoCurrencyId);
                    table.ForeignKey(
                        name: "FK_CryptoCurrencies_Wallets_WalletAddress",
                        column: x => x.WalletAddress,
                        principalTable: "Wallets",
                        principalColumn: "Address");
                });

            migrationBuilder.CreateTable(
                name: "FiatsCurrencies",
                columns: table => new
                {
                    FiatCurrencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WalletAddress = table.Column<string>(type: "nvarchar(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiatsCurrencies", x => x.FiatCurrencyId);
                    table.ForeignKey(
                        name: "FK_FiatsCurrencies_Wallets_WalletAddress",
                        column: x => x.WalletAddress,
                        principalTable: "Wallets",
                        principalColumn: "Address");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CryptoCurrencies_WalletAddress",
                table: "CryptoCurrencies",
                column: "WalletAddress");

            migrationBuilder.CreateIndex(
                name: "IX_FiatsCurrencies_WalletAddress",
                table: "FiatsCurrencies",
                column: "WalletAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptoCurrencies");

            migrationBuilder.DropTable(
                name: "FiatsCurrencies");

            migrationBuilder.DropTable(
                name: "Wallets");
        }
    }
}
