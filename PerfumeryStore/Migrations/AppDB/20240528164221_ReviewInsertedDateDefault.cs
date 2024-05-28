using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfumeryStore.Migrations.AppDB
{
    /// <inheritdoc />
    public partial class ReviewInsertedDateDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsertedDate",
                table: "Reviews",
                newName: "InsertedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InsertedDate",
                table: "Reviews",
                newName: "IsertedDate");
        }
    }
}
