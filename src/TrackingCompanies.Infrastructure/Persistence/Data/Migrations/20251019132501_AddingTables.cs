using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingCompanies.Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndexTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    RecommendedValue = table.Column<decimal>(type: "numeric", nullable: false),
                    IndexGroup = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexTypes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndexTypes");
        }
    }
}
