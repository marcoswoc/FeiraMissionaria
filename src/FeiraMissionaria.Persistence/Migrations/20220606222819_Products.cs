using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeiraMissionaria.Persistence.Migrations
{
    public partial class Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtcs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtcs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtcs_DeletedAt",
                table: "Produtcs",
                column: "DeletedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtcs");
        }
    }
}
