using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiTenancyDemo.Migrations
{
    /// <inheritdoc />
public partial class InitialMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Tenants",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                ConnectionString = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tenants", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Tenants_Name",
            table: "Tenants",
            column: "Name",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Tenants");
    }
}
}
