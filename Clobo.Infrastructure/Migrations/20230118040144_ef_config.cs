using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clobo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class efconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerUsers_Customers_CustomerId",
                table: "CustomerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketNotes_Tickets_TicketId",
                table: "TicketNotes");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerUsers_Customers_CustomerId",
                table: "CustomerUsers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketNotes_Tickets_TicketId",
                table: "TicketNotes",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerUsers_Customers_CustomerId",
                table: "CustomerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketNotes_Tickets_TicketId",
                table: "TicketNotes");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerUsers_Customers_CustomerId",
                table: "CustomerUsers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketNotes_Tickets_TicketId",
                table: "TicketNotes",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }
    }
}
