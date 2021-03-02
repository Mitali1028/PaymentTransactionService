using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentTransactionService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPaymentTransactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AmountBalance = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPaymentTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTransactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserPaymentTransactionId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentTransactions_UserPaymentTransactions_UserPaymentTransactionId",
                        column: x => x.UserPaymentTransactionId,
                        principalTable: "UserPaymentTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserPaymentTransactions",
                columns: new[] { "Id", "AmountBalance" },
                values: new object[] { 1L, 30000.0 });

            migrationBuilder.InsertData(
                table: "PaymentTransactions",
                columns: new[] { "Id", "Amount", "PaymentDate", "UserPaymentTransactionId" },
                values: new object[] { 1L, 1500.0, new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L });

            migrationBuilder.InsertData(
                table: "PaymentTransactions",
                columns: new[] { "Id", "Amount", "PaymentDate", "UserPaymentTransactionId" },
                values: new object[] { 2L, 1700.5, new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_UserPaymentTransactionId",
                table: "PaymentTransactions",
                column: "UserPaymentTransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentTransactions");

            migrationBuilder.DropTable(
                name: "UserPaymentTransactions");
        }
    }
}
