using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "CHAR(16) CHARACTER SET OCTETS", nullable: false),
                    Title = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: false),
                    CreateBy = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: false),
                    AssignedTo = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
