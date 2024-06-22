using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiteratureServer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class my_third_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Authors",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Authors");
        }
    }
}
