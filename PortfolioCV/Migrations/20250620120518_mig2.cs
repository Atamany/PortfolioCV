using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioCV.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SertifikaUrl",
                table: "Sertifikas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SertifikaUrl",
                table: "Sertifikas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
