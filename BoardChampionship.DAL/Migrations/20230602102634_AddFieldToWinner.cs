using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardChampionship.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldToWinner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Winners",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Winners");
        }
    }
}
