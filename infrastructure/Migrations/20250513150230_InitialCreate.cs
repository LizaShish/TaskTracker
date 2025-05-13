using System;
using FirebirdSql.EntityFrameworkCore.Firebird.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Fb:ValueGenerationStrategy", FbValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: false),
                    Description = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: false),
                    Status = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: false),
                    CreateBy = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: false),
                    AssignedTo = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
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
