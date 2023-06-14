using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCinema.Repository.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketInOrder_TicketInOrder_TicketInOrderTicketId_TicketInOrderOrderId",
                table: "TicketInOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketInShoppingCarts",
                table: "TicketInShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketInOrder",
                table: "TicketInOrder");

            migrationBuilder.DropIndex(
                name: "IX_TicketInOrder_TicketInOrderTicketId_TicketInOrderOrderId",
                table: "TicketInOrder");

            migrationBuilder.DropColumn(
                name: "TicketInOrderOrderId",
                table: "TicketInOrder");

            migrationBuilder.DropColumn(
                name: "TicketInOrderTicketId",
                table: "TicketInOrder");

            migrationBuilder.AddColumn<Guid>(
                name: "TicketInOrderId",
                table: "TicketInOrder",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketInShoppingCarts",
                table: "TicketInShoppingCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketInOrder",
                table: "TicketInOrder",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TicketInShoppingCarts_TicketId",
                table: "TicketInShoppingCarts",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketInOrder_TicketId",
                table: "TicketInOrder",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketInOrder_TicketInOrderId",
                table: "TicketInOrder",
                column: "TicketInOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInOrder_TicketInOrder_TicketInOrderId",
                table: "TicketInOrder",
                column: "TicketInOrderId",
                principalTable: "TicketInOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketInOrder_TicketInOrder_TicketInOrderId",
                table: "TicketInOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketInShoppingCarts",
                table: "TicketInShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_TicketInShoppingCarts_TicketId",
                table: "TicketInShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketInOrder",
                table: "TicketInOrder");

            migrationBuilder.DropIndex(
                name: "IX_TicketInOrder_TicketId",
                table: "TicketInOrder");

            migrationBuilder.DropIndex(
                name: "IX_TicketInOrder_TicketInOrderId",
                table: "TicketInOrder");

            migrationBuilder.DropColumn(
                name: "TicketInOrderId",
                table: "TicketInOrder");

            migrationBuilder.AddColumn<Guid>(
                name: "TicketInOrderOrderId",
                table: "TicketInOrder",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TicketInOrderTicketId",
                table: "TicketInOrder",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketInShoppingCarts",
                table: "TicketInShoppingCarts",
                columns: new[] { "TicketId", "ShoppingCartId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketInOrder",
                table: "TicketInOrder",
                columns: new[] { "TicketId", "OrderId" });

            migrationBuilder.CreateIndex(
                name: "IX_TicketInOrder_TicketInOrderTicketId_TicketInOrderOrderId",
                table: "TicketInOrder",
                columns: new[] { "TicketInOrderTicketId", "TicketInOrderOrderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInOrder_TicketInOrder_TicketInOrderTicketId_TicketInOrderOrderId",
                table: "TicketInOrder",
                columns: new[] { "TicketInOrderTicketId", "TicketInOrderOrderId" },
                principalTable: "TicketInOrder",
                principalColumns: new[] { "TicketId", "OrderId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
